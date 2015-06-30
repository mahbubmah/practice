using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;
using System.IO;
using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;

namespace OB.Web.BookAdmin
{
    public partial class OiiOBookWF : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessLogoContent = "seLogoContent";
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Session["seOthercontentPicTempFileName"] = null;
                    LoadLogoContentListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    chkOiiObookActv.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadLogoContentListView()
        {
            try
            {
                using (OiiOBookRT receiverTransfer = new OiiOBookRT())
                {
                    lvOiiObook.DataSource = receiverTransfer.GetOiiOContentAllForListView(); ;
                    lvOiiObook.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;

                using (OiiOBookRT receiverTransfer = new OiiOBookRT())
                {
                    bool bookContentNotActive = receiverTransfer.GetActiveBookContent();
                    if (bookContentNotActive)
                    {
                        hdSave.Value = "true";
                        OiiOBook Oiioother = CreateOtherContent();
                        receiverTransfer.AddOtherContent(Oiioother);
                        if (Oiioother.IID > 0)
                        {
                            labelMessage.Text = "Data successfully saved...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Data not saved...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        labelMessage.Text = "You Can't Enter A content while other content Active.You must Deactive All content First";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadLogoContentListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            chkOiiObookActv.Checked = false;
            chkOiiObookActv.Visible = false;
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

        private OiiOBook CreateOtherContent()
        {
            Session["UserID"] = "1";
            OiiOBook OiioBook = new OiiOBook();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    OiioBook.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                OiioBook.CompanyName = txtCompanyName.Text.Trim();
                OiioBook.Email = txtEmail.Text.Trim();
                OiioBook.Address = txtAddress.Text.Trim();
                OiioBook.Phone = txtPhone.Text;
                OiioBook.Note = txtNote.Text;

                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile)
                {
                    OiioBook.Logo = OiiOHaatImageUpload().ToString();
                    if (FileUploadImageForLoginLogo.HasFile)
                    {
                        OiioBook.LoginLogo = OiiOHaatImageUploadForLoginLogo().ToString();
                    }


                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile)
                {
                    OiioBook.Logo = OiiOHaatImageUpload().ToString();
                    if (txtHoldImagePathForLoginLogo.Text != null && FileUploadImageForLoginLogo.HasFile)
                    {
                        OiioBook.LoginLogo = OiiOHaatImageUploadForLoginLogo().ToString();
                    }
                    else
                    {
                        OiioBook.LoginLogo = txtHoldImagePathForLoginLogo.Text;
                    }

                }
                else
                {
                    if (FileUploadImageForLoginLogo.HasFile)
                    {
                        OiioBook.LoginLogo = OiiOHaatImageUploadForLoginLogo().ToString();
                    }
                    else
                    {
                        OiioBook.LoginLogo = txtHoldImagePathForLoginLogo.Text;
                    }
                    OiioBook.Logo = txtHoldImagePath.Text;

                }
                if (OiioBook.IID <= 0)
                {
                    OiioBook.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    OiioBook.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    OiiOBook Oiioother = (OiiOBook)Session[sessLogoContent];
                    OiioBook.CreatedBy = Oiioother.CreatedBy; ;
                    OiioBook.CreatedDate = Oiioother.CreatedDate;
                    OiioBook.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    OiioBook.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkOiiObookActv.Checked == true) || (hdSave.Value == "true" && chkOiiObookActv.Checked != true))
                {
                    OiioBook.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkOiiObookActv.Checked == false)
                {
                    OiioBook.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return OiioBook;
        }

        private object OiiOHaatImageUploadForLoginLogo()
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (FileUploadImageForLoginLogo.HasFile)
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
                    string path = Server.MapPath("~/Image/OiiOLogo/");
                    FileUploadHelper.BindImage(FileUploadImageForLoginLogo, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/Image/OiiOLogo/" + tempMatImageName + Path.GetExtension(FileUploadImageForLoginLogo.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        private object OiiOHaatImageUpload()
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
                    string path = Server.MapPath("~/Image/OiiOLogo/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/Image/OiiOLogo/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        int lvRowCount = 0;
        int currentPage = 0;

        protected void lvOiiObook_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvOiiObook_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditOiiObook")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    chkOiiObookActv.Visible = true;
                    int ContentID = Convert.ToInt32(e.CommandArgument);
                    hdContentID.Value = ContentID.ToString();
                    using (OiiOBookRT receiverTransfer = new OiiOBookRT ())
                    {
                        OiiOBook oIIobook = receiverTransfer.GetOtherContentByIID(ContentID);
                        FillOtherContentForEdit(oIIobook);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillOtherContentForEdit(OiiOBook oIIobook)
        {
            try
            {
                if (oIIobook != null)
                {

                    txtCompanyName.Text = oIIobook.CompanyName;
                    txtEmail.Text = oIIobook.Email.ToString();
                    txtAddress.Text = oIIobook.Address;
                    txtHoldImagePath.Text = oIIobook.Logo;
                    txtHoldImagePathForLoginLogo.Text = oIIobook.LoginLogo;
                    txtPhone.Text = oIIobook.Phone;
                    txtNote.Text = oIIobook.Note.ToString();
                    if (oIIobook.IsActive == true)
                    {

                        chkOiiObookActv.Checked = true;

                    }
                    else
                    {
                        chkOiiObookActv.Checked = false;
                    }
                    Session[sessLogoContent] = oIIobook;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerContent_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadLogoContentListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (OiiOBookRT receiverTransfer = new OiiOBookRT())
                {
                    hdIsEdit.Value = "true";
                    OiiOBook oiiocontent = CreateOtherContent();

                    if (oiiocontent != null)
                    {

                        if (receiverTransfer.IsExistCMSType(oiiocontent.IID))
                        {
                            labelMessage.Text = "Other OiiOBook content is already active ...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            receiverTransfer.Updateoiiocontent(oiiocontent);
                            labelMessage.Text = "Data successfully updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadLogoContentListView();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessage.Text = "";
            btnVisibilityForCancel();
        }
    }
}