using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;
using System.IO;
using DAL;
using BLL.Basic;
using Utilities;


namespace OMart.Web.AdminPanel
{
    public partial class OiiOMartContent : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessMartContent = "seMartContent";
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["seOthercontentPicTempFileName"] = null;
                LoadMartContentListView();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = false;
                chkOiiOmartActv.Visible = false;
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "Error : " + ex.Message;
                labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadMartContentListView()
        {
            try
            {
                using (OiiOMartRT receiverTransfer = new OiiOMartRT())
                {
                    lvMartContent.DataSource = receiverTransfer.GetOiiOContentAllForListView(); ;
                    lvMartContent.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "Error : " + ex.Message;
                labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageOiiOMart.Text = string.Empty;

                using (OiiOMartRT receiverTransfer = new OiiOMartRT())
                {
                    bool haatContentNotActive = receiverTransfer.GetActiveMartContent();
                    if (haatContentNotActive)
                    {
                        hdSave.Value = "true";
                        OiiOMart Oiioother = CreateOtherContent();
                        receiverTransfer.AddOtherContent(Oiioother);
                        if (Oiioother.IID > 0)
                        {
                            labelMessageOiiOMart.Text = "Data successfully saved...";
                            labelMessageOiiOMart.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessageOiiOMart.Text = "Data not saved...";
                            labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        labelMessageOiiOMart.Text = "You Can't Enter A content while other content Active.You must Deactive All content First";
                        labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadMartContentListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "Error : " + ex.Message;
                labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtAddress.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            // txtHoldImagePath.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private OiiOMart CreateOtherContent()
        {
            Session["UserID"] = "1";
            OiiOMart OiioMart = new OiiOMart();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    OiioMart.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                OiioMart.CompanyName = txtCompanyName.Text.Trim();
                OiioMart.Email = txtEmail.Text.Trim();
                OiioMart.Address = txtAddress.Text.Trim();
                OiioMart.Phone = txtPhone.Text;
                OiioMart.Note = txtNote.Text;
                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    OiioMart.Logo = OiiOMartImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    OiioMart.Logo = OiiOMartImageUpload().ToString();
                }
                else
                {
                    OiioMart.Logo = txtHoldImagePath.Text;
                }
                if (OiioMart.IID <= 0)
                {
                    OiioMart.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    OiioMart.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    OiiOMart Oiioother = (OiiOMart)Session[sessMartContent];
                    OiioMart.CreatedBy = Oiioother.CreatedBy; ;
                    OiioMart.CreatedDate = Oiioother.CreatedDate;
                    OiioMart.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    OiioMart.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkOiiOmartActv.Checked == true) || (hdSave.Value == "true" && chkOiiOmartActv.Checked != true))
                {
                    OiioMart.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkOiiOmartActv.Checked == false)
                {
                    OiioMart.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "Error : " + ex.Message;
                labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
            }
            return OiioMart;
        }

        private object OiiOMartImageUpload()
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (FileUploadImage.HasFile)
                {
                    string now = "";
                    now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
                    //take only letter or digit
                    var sb = new StringBuilder();
                    foreach (char t in now.Where(char.IsLetterOrDigit))
                    {
                        sb.Append(t);
                    }
                    now = sb.ToString();//save to now string
                    var rnd = new Random(100000);
                    var tempMatImageName = now + rnd.Next();
                    string path = Server.MapPath("~/Images/logo/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/Images/logo/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        int lvRowCount = 0;
        int currentPage = 0;

        protected void lvMartContent_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvMartContent_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMartContent")
            {
                try
                {
                    labelMessageOiiOMart.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    chkOiiOmartActv.Visible = true;
                    int HaatContentID = Convert.ToInt32(e.CommandArgument);
                    hdContentID.Value = HaatContentID.ToString();
                    using (OiiOMartRT receiverTransfer = new OiiOMartRT())
                    {
                        OiiOMart oIIomart = receiverTransfer.GetOtherContentByIID(HaatContentID);
                        FillOtherContentForEdit(oIIomart);
                    }
                }
                catch (Exception ex)
                {
                    labelMessageOiiOMart.Text = "Error : " + ex.Message;
                    labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillOtherContentForEdit(OiiOMart oIIomart)
        {
            try
            {
                if (oIIomart != null)
                {

                    txtCompanyName.Text = oIIomart.CompanyName;
                    txtEmail.Text = oIIomart.Email.ToString();
                    txtAddress.Text = oIIomart.Address;
                    txtHoldImagePath.Text = oIIomart.Logo;
                    txtPhone.Text = oIIomart.Phone;
                    txtNote.Text = oIIomart.Note.ToString();
                    if (oIIomart.IsActive == true)
                    {

                        chkOiiOmartActv.Checked = true;

                    }
                    else
                    {
                        chkOiiOmartActv.Checked = false;
                    }
                    Session[sessMartContent] = oIIomart;
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "Error : " + ex.Message;
                labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerMartContent_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMartContentListView();
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "Error : " + ex.Message;
                labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (OiiOMartRT receiverTransfer = new OiiOMartRT())
                {
                    hdIsEdit.Value = "true";
                    OiiOMart oiiomartcontent = CreateOtherContent();

                    if (oiiomartcontent != null)
                    {

                        if (receiverTransfer.IsActiveOtherContent(oiiomartcontent.IID))
                        {
                            labelMessageOiiOMart.Text = "Other OiiOMart content is already active ...";
                            labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            receiverTransfer.Updateoiiomartcontent(oiiomartcontent);
                            labelMessageOiiOMart.Text = "Data successfully updated...";
                            labelMessageOiiOMart.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        labelMessageOiiOMart.Text = "Data not updated...";
                        labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadMartContentListView();
                hdIsEdit.Value = null;
            }
            catch (Exception ex)
            {
                labelMessageOiiOMart.Text = "Error : " + ex.Message;
                labelMessageOiiOMart.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            chkOiiOmartActv.Checked = false;
            chkOiiOmartActv.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessageOiiOMart.Text = "";
            btnVisibilityForCancel();
        }
    }
}