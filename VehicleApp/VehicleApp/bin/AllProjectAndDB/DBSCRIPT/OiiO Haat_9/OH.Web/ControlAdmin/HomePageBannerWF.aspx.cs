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
    public partial class HomePageBannerWF : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessBanner = "seBanner";
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
                    LoadBannerListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    chkBannerActv.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageBanner.Text = "Error : " + ex.Message;
                    labelMessageBanner.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadBannerListView()
        {
            try
            {
                using (BannerRT receiverTransfer = new BannerRT())
                {
                    lvBanner.DataSource = receiverTransfer.GetOiiOBannerAllForListView(); ;
                    lvBanner.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageBanner.Text = "Error : " + ex.Message;
                labelMessageBanner.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageBanner.Text = string.Empty;

                using (BannerRT receiverTransfer = new BannerRT())
                {
                    //bool haatContentNotActive = receiverTransfer.GetActiveHaatContent();
                    //if (haatContentNotActive)
                    //{
                        hdSave.Value = "true";
                        HomePageBanner OiioBanner = CreateBanner();
                        receiverTransfer.AddOtherContent(OiioBanner);
                        if (OiioBanner.IID > 0)
                        {
                            labelMessageBanner.Text = "Data successfully saved...";
                            labelMessageBanner.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessageBanner.Text = "Data not saved...";
                            labelMessageBanner.ForeColor = System.Drawing.Color.Red;
                        }
                    //}
                    //else
                    //{
                    //    labelMessageOiiOHaaT.Text = "You Can't Enter A content while other content Active.You must Deactive All content First";
                    //    labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;
                    //}
                }

                ClearField();
                LoadBannerListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                labelMessageBanner.Text = "Error : " + ex.Message;
                labelMessageBanner.ForeColor = System.Drawing.Color.Red;
            }
        }

        private HomePageBanner CreateBanner()
        {
            Session["UserID"] = "1";
            HomePageBanner OiioBanner = new HomePageBanner();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    OiioBanner.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                OiioBanner.Title = txtTitle.Text.Trim();
                OiioBanner.Note = txtNote.Text.Trim();
                
                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    OiioBanner.Image = OiiOBannErImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    OiioBanner.Image = OiiOBannErImageUpload().ToString();
                }
                else
                {
                    OiioBanner.Image = txtHoldImagePath.Text;
                }
                if (OiioBanner.IID <= 0)
                {
                    OiioBanner.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    OiioBanner.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    HomePageBanner Oiioother = (HomePageBanner)Session[sessBanner];
                    OiioBanner.CreatedBy = Oiioother.CreatedBy; ;
                    OiioBanner.CreatedDate = Oiioother.CreatedDate;
                    OiioBanner.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    OiioBanner.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkBannerActv.Checked == true) || (hdSave.Value == "true" && chkBannerActv.Checked != true))
                {
                    OiioBanner.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkBannerActv.Checked == false)
                {
                    OiioBanner.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                labelMessageBanner.Text = "Error : " + ex.Message;
                labelMessageBanner.ForeColor = System.Drawing.Color.Red;
            }
            return OiioBanner;
        }

        private object OiiOBannErImageUpload()
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
                    string path = Server.MapPath("~/Image/Banner/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/Image/Banner/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                labelMessageBanner.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvBanner_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBanner")
            {
                try
                {
                    labelMessageBanner.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    chkBannerActv.Visible = true;
                    int HaatBannerID = Convert.ToInt32(e.CommandArgument);
                    hdContentID.Value = HaatBannerID.ToString();
                    using (BannerRT receiverTransfer = new BannerRT())
                    {
                        HomePageBanner oIIobanner = receiverTransfer.GetOtherContentByIID(HaatBannerID);
                        FillOtherContentForEdit(oIIobanner);
                    }
                }
                catch (Exception ex)
                {
                    labelMessageBanner.Text = "Error : " + ex.Message;
                    labelMessageBanner.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillOtherContentForEdit(HomePageBanner oIIobanner)
        {
            try
            {
                if (oIIobanner != null)
                {

                    txtHoldImagePath.Text = oIIobanner.Image;
                    txtTitle.Text = oIIobanner.Title.ToString();
                    txtNote.Text = oIIobanner.Note.ToString();
                    if (oIIobanner.IsActive == true)
                    {

                        chkBannerActv.Checked = true;

                    }
                    else
                    {
                        chkBannerActv.Checked = false;
                    }
                    Session[sessBanner] = oIIobanner;
                }
            }
            catch (Exception ex)
            {
                labelMessageBanner.Text = "Error : " + ex.Message;
                labelMessageBanner.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvBanner_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerBanner_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadBannerListView();
                }
            }
            catch (Exception ex)
            {
                labelMessageBanner.Text = "Error : " + ex.Message;
                labelMessageBanner.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            chkBannerActv.Checked = false;
            chkBannerActv.Visible = false;
        }
        private void ClearField()
        {
            txtNote.Text = string.Empty;
            txtTitle.Text = string.Empty;
           

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (BannerRT receiverTransfer = new BannerRT())
                {
                    hdIsEdit.Value = "true";
                    HomePageBanner oiiohaatbanner = CreateBanner();

                    if (oiiohaatbanner != null)
                    {

                        //if (receiverTransfer.IsExistCMSType(oiiohaatbanner.IID))
                        //{
                        //    labelMessageOiiOHaaT.Text = "Other OiiOhaat content is already active ...";
                        //    labelMessageOiiOHaaT.ForeColor = System.Drawing.Color.Red;

                        //}
                        //else
                        //{
                        receiverTransfer.Updateoiiohaatbanner(oiiohaatbanner);
                            labelMessageBanner.Text = "Data successfully updated...";
                            labelMessageBanner.ForeColor = System.Drawing.Color.Green;
                        //}
                    }
                    else
                    {
                        labelMessageBanner.Text = "Data not updated...";
                        labelMessageBanner.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadBannerListView();
            }
            catch (Exception ex)
            {
                labelMessageBanner.Text = "Error : " + ex.Message;
                labelMessageBanner.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessageBanner.Text = "";
            btnVisibilityForCancel();
        }
    }
}