using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System.Globalization;
using System.Text;
using System.IO;

namespace OH.Web.ControlAdmin
{
    public partial class OiiOhaatPage : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessHaatContent = "seHaatContent";
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
                    LoadotherContentListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    chkOiiOhaatActv.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                    labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageOiiOHaaT.Text = string.Empty;

                using (OiiOHaatRT receiverTransfer = new OiiOHaatRT())
                {
                      bool haatContentNotActive = receiverTransfer.GetActiveHaatContent();
                      if (haatContentNotActive)
                      {
                          hdSave.Value = "true";
                          OiiOHaat Oiioother = CreateOtherContent();
                          receiverTransfer.AddOtherContent(Oiioother);
                          if (Oiioother.IID > 0)
                          {
                              labelMessageOiiOHaaT.Text = "Data successfully saved...";
                              labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Green;
                          }
                          else
                          {
                              labelMessageOiiOHaaT.Text = "Data not saved...";
                              labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
                          }
                      }
                      else
                      {
                          labelMessageOiiOHaaT.Text = "You Can't Enter A content while other content Active.You must Deactive All content First";
                          labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
                      }
                }

                ClearField();
                LoadotherContentListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadotherContentListView()
        {
            try
            {
                using (OiiOHaatRT receiverTransfer = new OiiOHaatRT())
                {
                    lvHaaTContent.DataSource = receiverTransfer.GetOiiOContentAllForListView(); ;
                    lvHaaTContent.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
            }
        }

        private OiiOHaat CreateOtherContent()
        {
            Session["UserID"] = "1";
            OiiOHaat OiioHaat = new OiiOHaat();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    OiioHaat.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                OiioHaat.CompanyName = txtCompanyName.Text.Trim();
                OiioHaat.Email = txtEmail.Text.Trim();
                OiioHaat.Address = txtAddress.Text.Trim();
                OiioHaat.Phone = txtPhone.Text;
                OiioHaat.Note = txtNote.Text;

                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile)
                {
                    OiioHaat.Logo = OiiOHaatImageUpload().ToString();
                    if(FileUploadImageForLoginLogo.HasFile)
                    {
                        OiioHaat.LoginLogo = OiiOHaatImageUploadForLoginLogo().ToString();
                    }
                   
                    
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile)
                {
                    OiioHaat.Logo = OiiOHaatImageUpload().ToString();
                    if(txtHoldImagePathForLoginLogo.Text!=null&&FileUploadImageForLoginLogo.HasFile)
                    {
                        OiioHaat.LoginLogo = OiiOHaatImageUploadForLoginLogo().ToString();
                    }
                    else
                    {
                        OiioHaat.LoginLogo = txtHoldImagePathForLoginLogo.Text;
                    }
                    
                }
                else
                {
                    if(FileUploadImageForLoginLogo.HasFile)
                    {
                        OiioHaat.LoginLogo = OiiOHaatImageUploadForLoginLogo().ToString();
                    }
                    else
                    {
                        OiioHaat.LoginLogo = txtHoldImagePathForLoginLogo.Text;
                    }
                    OiioHaat.Logo = txtHoldImagePath.Text;
                   
                }
                if (OiioHaat.IID <= 0)
                {
                    OiioHaat.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    OiioHaat.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    OiiOHaat Oiioother = (OiiOHaat)Session[sessHaatContent];
                    OiioHaat.CreatedBy = Oiioother.CreatedBy; ;
                    OiioHaat.CreatedDate = Oiioother.CreatedDate;
                    OiioHaat.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    OiioHaat.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkOiiOhaatActv.Checked == true) || (hdSave.Value == "true" && chkOiiOhaatActv.Checked != true))
                {
                    OiioHaat.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkOiiOhaatActv.Checked == false)
                {
                    OiioHaat.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
            }
            return OiioHaat;
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
                labelMessageOiiOHaaT.Text = "error: " + ex.Message;
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
                labelMessageOiiOHaaT.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            chkOiiOhaatActv.Checked = false;
            chkOiiOhaatActv.Visible = false;
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
        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvHaaTContent_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvHaaTContent_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditHaaTContent")
            {
                try
                {
                    labelMessageOiiOHaaT.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    chkOiiOhaatActv.Visible = true;
                    int HaatContentID = Convert.ToInt32(e.CommandArgument);
                    hdContentID.Value = HaatContentID.ToString();
                    using (OiiOHaatRT receiverTransfer = new OiiOHaatRT())
                    {
                        OiiOHaat oIIohaat = receiverTransfer.GetOtherContentByIID(HaatContentID);
                        FillOtherContentForEdit(oIIohaat);
                    }
                }
                catch (Exception ex)
                {
                    labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                    labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillOtherContentForEdit(OiiOHaat oIIohaat)
        {
            try
            {
                if (oIIohaat != null)
                {

                    txtCompanyName.Text = oIIohaat.CompanyName;
                    txtEmail.Text = oIIohaat.Email.ToString();
                    txtAddress.Text = oIIohaat.Address;
                    txtHoldImagePath.Text = oIIohaat.Logo;
                    txtHoldImagePathForLoginLogo.Text = oIIohaat.LoginLogo;
                    txtPhone.Text = oIIohaat.Phone;
                    txtNote.Text = oIIohaat.Note.ToString();
                    if (oIIohaat.IsActive == true)
                    {

                        chkOiiOhaatActv.Checked = true;

                    }
                    else
                    {
                        chkOiiOhaatActv.Checked = false;
                    }
                    Session[sessHaatContent] = oIIohaat;
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerContent_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadotherContentListView();
                }
            }
            catch (Exception ex)
            {
                labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (OiiOHaatRT receiverTransfer = new OiiOHaatRT())
                {
                    hdIsEdit.Value = "true";
                    OiiOHaat oiiohaatcontent = CreateOtherContent();

                    if (oiiohaatcontent != null)
                    {

                        if (receiverTransfer.IsExistCMSType(oiiohaatcontent.IID))
                        {
                            labelMessageOiiOHaaT.Text = "Other OiiOhaat content is already active ...";
                            labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            receiverTransfer.Updateoiiohaatcontent(oiiohaatcontent);
                            labelMessageOiiOHaaT.Text = "Data successfully updated...";
                            labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        labelMessageOiiOHaaT.Text = "Data not updated...";
                        labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadotherContentListView();
            }
            catch (Exception ex)
            {
                labelMessageOiiOHaaT.Text = "Error : " + ex.Message;
                labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessageOiiOHaaT.Text = "";
            btnVisibilityForCancel();
        }
    }
}