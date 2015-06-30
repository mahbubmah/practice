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
    public partial class OiiOOtherContentWF : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessOtherContent = "seOtherContent";
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
                    chkOtherContentActv.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageOtherContent.Text = "Error : " + ex.Message;
                    labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageOtherContent.Text = string.Empty;

                using (OtherContentRT receiverTransfer = new OtherContentRT())
                {
                    hdSave.Value = "true";
                    OiiOOther Oiioother = CreateOtherContent();              
                    receiverTransfer.AddOtherContent(Oiioother);              
                    if (Oiioother.IID > 0)
                    {
                        labelMessageOtherContent.Text = "Data successfully saved...";
                        labelMessageOtherContent.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageOtherContent.Text = "Data not saved...";
                        labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadotherContentListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                labelMessageOtherContent.Text = "Error : " + ex.Message;
                labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadotherContentListView()
        {
            try
            {
                using (OtherContentRT receiverTransfer = new OtherContentRT())
                {
                    lvContent.DataSource = receiverTransfer.GetotherContentAllForListView(); ;
                    lvContent.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageOtherContent.Text = "Error : " + ex.Message;
                labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtContentTitle.Text = string.Empty;
            txtDetailsDiscription.Text = string.Empty;
            txtShortDiscription.Text = string.Empty;
        }

        private OiiOOther CreateOtherContent()
        {
            Session["UserID"] = "1";
            OiiOOther OiioOther = new OiiOOther();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    OiioOther.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                OiioOther.Title = txtContentTitle.Text.Trim();
                OiioOther.ShortDescription = txtShortDiscription.Text.Trim();
                OiioOther.DetailDescription = txtDetailsDiscription.Text.Trim();
                
                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    OiioOther.ImageUrl = ImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile==true)
                {
                    OiioOther.ImageUrl = ImageUpload().ToString();
                }
                else
                {
                    OiioOther.ImageUrl = txtHoldImagePath.Text;
                }
                if (OiioOther.IID <= 0)
                {
                    OiioOther.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    OiioOther.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    OiiOOther Oiioother = (OiiOOther)Session[sessOtherContent];
                    OiioOther.CreatedBy = Oiioother.CreatedBy; ;
                    OiioOther.CreatedDate = Oiioother.CreatedDate;
                    OiioOther.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    OiioOther.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkOtherContentActv.Checked == true) || (hdSave.Value == "true" && chkOtherContentActv.Checked != true))
                {
                    OiioOther.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkOtherContentActv.Checked == false)
                {
                    OiioOther.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                labelMessageOtherContent.Text = "Error : " + ex.Message;
                labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            }
            return OiioOther;
        }

        private string ImageUpload()
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
                    string path = Server.MapPath("~/Image/OtherContentImage/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName, 800, 800);
                    imageUrl.ImageUrlTemp = "~/Image/OtherContentImage/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                labelMessageOtherContent.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (OtherContentRT receiverTransfer = new OtherContentRT())
                {
                    hdIsEdit.Value = "true";
                    OiiOOther oiiocontent = CreateOtherContent();

                    if (oiiocontent != null)
                    {
                        receiverTransfer.Updateoiiocontent(oiiocontent);
                        labelMessageOtherContent.Text = "Data successfully updated...";
                        labelMessageOtherContent.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageOtherContent.Text = "Data not updated...";
                        labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadotherContentListView();
            }
            catch (Exception ex)
            {
                labelMessageOtherContent.Text = "Error : " + ex.Message;
                labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            chkOtherContentActv.Checked = false;
            chkOtherContentActv.Visible = false;
        }

        protected void lvContent_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditContent")
            {
                try
                {
                    labelMessageOtherContent.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    chkOtherContentActv.Visible = true;
                    int OtherContentID = Convert.ToInt32(e.CommandArgument);
                    hdContentID.Value = OtherContentID.ToString();
                    using (OtherContentRT receiverTransfer = new OtherContentRT())
                    {
                        OiiOOther oIIoother = receiverTransfer.GetOtherContentByIID(OtherContentID);
                        FillOtherContentForEdit(oIIoother);
                    }
                }
                catch (Exception ex)
                {
                    labelMessageOtherContent.Text = "Error : " + ex.Message;
                    labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillOtherContentForEdit(OiiOOther oIIoother)
        {
            try
            {
                if (oIIoother != null)
                {

                    txtContentTitle.Text = oIIoother.Title;
                    txtShortDiscription.Text = oIIoother.ShortDescription.ToString();
                    txtDetailsDiscription.Text = oIIoother.DetailDescription;
                    txtHoldImagePath.Text = oIIoother.ImageUrl;
                    if (oIIoother.IsActive == true)
                    {

                        chkOtherContentActv.Checked = true;

                    }
                    else
                    {
                        chkOtherContentActv.Checked = false;
                    }
                    Session[sessOtherContent] = oIIoother;
                }
            }
            catch (Exception ex)
            {
                labelMessageOtherContent.Text = "Error : " + ex.Message;
                labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        
             

        protected void lvContent_PagePropertiesChanged(object sender, EventArgs e)
        {
           
        }
        int lvRowCount = 0;
        int currentPage = 0;
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
                labelMessageOtherContent.Text = "Error : " + ex.Message;
                labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvContent_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    labelMessageOtherContent.Text = string.Empty;
            //    using (OtherContentRT receiverTransfer = new OtherContentRT())
            //    {
            //        hdIsDelete.Value = "true";
            //        hdIsEdit.Value = "true";
            //        OiiOOther oiiOOther = CreateOtherContent();

            //        if (oiiOOther != null)
            //        {
            //            receiverTransfer.Updateoiiocontent(oiiOOther);
            //            labelMessageOtherContent.Text = "Data successfully deleted...";
            //            labelMessageOtherContent.ForeColor = System.Drawing.Color.Green;
            //        }
            //        else
            //        {
            //            labelMessageOtherContent.Text = "Data not deleted...";
            //            labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    LoadotherContentListView();
            //    btnVisibilityForCancel();
            //    hdIsDelete.Value = "false";
               
            //    ClearField();
            //}
            //catch (Exception ex)
            //{
            //    labelMessageOtherContent.Text = "Error : " + ex.Message;
            //    labelMessageOtherContent.ForeColor = System.Drawing.Color.Red;
            //}

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessageOtherContent.Text = "";
            btnVisibilityForCancel();
        }

    }
}