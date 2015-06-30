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
    public partial class BookNewsWF : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessBookNews = "seBookNews";
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
              
                    Session["seOthercontentPicTempFileName"] = null;
                    LoadBookNewsListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    chkRemove.Visible = false;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadBookNewsListView()
        {
            try
            {
                using (BookNewsRT receiverTransfer = new BookNewsRT())
                {
                    lvBookNews.DataSource = receiverTransfer.GetNEWSContentAllForListView();
                    lvBookNews.DataBind();


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

                using (BookNewsRT receiverTransfer = new BookNewsRT())
                {
                 
                        hdSave.Value = "true";
                        BookNews newsontent = Createnewscontent();
                        receiverTransfer.AddNewsContent(newsontent);
                        if (newsontent.IID > 0)
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


                ClearField();
                LoadBookNewsListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtAudio.Text = string.Empty;
            txtBookDescription.Text = string.Empty;
            txtNewsHeadLine.Text = string.Empty;
            txtPublishDate.Text = string.Empty;
            txtVideo.Text = string.Empty;
            chkRemove.Checked = false;
           
        }
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            chkRemove.Visible = false;

        }

        private BookNews Createnewscontent()
        {
            Session["UserID"] = "1";
            BookNews Booknews = new BookNews();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    Booknews.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                Booknews.HeadLine = txtNewsHeadLine.Text.Trim();
                Booknews.NewsDescription = txtBookDescription.Text.Trim();
                Booknews.PublishDate = DateTime.ParseExact(txtPublishDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                Booknews.VideoLink = txtVideo.Text;
                Booknews.Audio = txtAudio.Text;

                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    Booknews.ImageUrl = ImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    Booknews.ImageUrl = ImageUpload().ToString();
                }
                else
                {
                    Booknews.ImageUrl = txtHoldImagePath.Text;
                }
                if (Booknews.IID <= 0)
                {
                    Booknews.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    Booknews.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    BookNews bookNews = (BookNews)Session[sessBookNews];
                    Booknews.CreatedBy = bookNews.CreatedBy; ;
                    Booknews.CreatedDate = bookNews.CreatedDate;
                    Booknews.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    Booknews.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkRemove.Checked == false) || (hdSave.Value == "true" && chkRemove.Checked == false))
                {
                    Booknews.IsRemoved = false;
                }
                else if (hdIsEdit.Value == "true" && chkRemove.Checked == true)
                {
                    Booknews.IsRemoved = true;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return Booknews;
        }

        private object ImageUpload()
        {
            List<ImageUrl> cmsPicTempFileUrlList = new List<ImageUrl>();
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
                    string path = Server.MapPath("~/Image/BookNewsImage/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/Image/BookNewsImage/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

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

        protected void lvABookNews_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerBookNews_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadBookNewsListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                chkRemove.Visible = true;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                LinkButton linkButton = (LinkButton)sender;
                Int64 Booknews = Convert.ToInt64(linkButton.CommandArgument);
                hdContentID.Value = Booknews.ToString();
                using (BookNewsRT receiverTransfer = new BookNewsRT())
                {
                    BookNews CMScontent = receiverTransfer.GetOtherContentByIID(Booknews);
                    FillCMScontentForEdit(CMScontent);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void FillCMScontentForEdit(BookNews CMScontent)
        {
            try
            {
                if (CMScontent != null)
                {

                   
                    txtAudio.Text = CMScontent.Audio;
                    txtNewsHeadLine.Text = CMScontent.HeadLine;
                   
                    txtBookDescription.Text = CMScontent.NewsDescription;
                    txtHoldImagePath.Text = CMScontent.ImageUrl;
                    txtVideo.Text = CMScontent.VideoLink;
                    if (Request.Browser.Browser == "Chrome" || Request.Browser.Browser == " ")
                    {
                        txtPublishDate.Text = CMScontent.PublishDate.Date.ToString("MM/dd/yyyy");
                       
                    }
                    else
                    {
                        txtPublishDate.Text = CMScontent.PublishDate.Date.ToString("MM/dd/yyyy");
                        
                    }
                    if (CMScontent.IsRemoved == true)
                    {

                        chkRemove.Checked = true;

                    }
                    else
                    {
                        chkRemove.Checked = false;
                    }
                    Session[sessBookNews] = CMScontent;
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
                labelMessage.Text = string.Empty;
                using (BookNewsRT receiverTransfer = new BookNewsRT())
                {
                    hdIsEdit.Value = "true";
                    BookNews booknewsupdate = Createnewscontent();

                    if (booknewsupdate != null)
                    {

                
                            receiverTransfer.UpdateCMScontent(booknewsupdate);
                            labelMessage.Text = "Data successfully updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                       

                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                }
                ClearField();
                btnVisibilityForCancel();
                LoadBookNewsListView();
                txtHoldImagePath.Text = string.Empty;
                hdIsEdit.Value = string.Empty;
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