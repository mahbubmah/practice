using BLL.Basic;
using OB.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OB.Web.BookAdmin
{
    public partial class PublisherInsertUpdate : System.Web.UI.Page
    {
         private readonly BookPublisherRT _BookPublisherRT;
        private long IID = default(Int64);

        public PublisherInsertUpdate()
        {
            this._BookPublisherRT = new BookPublisherRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowPublisherData();
                       
                    }
                   
                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
              //  string PublisherName = string.Empty;

                BookPublisher Publisher = CreateBookPublisher();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(Publisher); 
               // PublisherName = Publisher.PublisherName;   
               // ImageUrl imageUrl = new ImageUrl();
               
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        Publisher.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        Publisher.CreatedDate = DateTime.Now;
                        Publisher.IsRemoved = false;

                        _BookPublisherRT.AddBookPublisher(Publisher);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        BookPublisher objPublisher = _BookPublisherRT.GetBookPublisherByIID(IID);

                        if (objPublisher != null)
                        {
                            Publisher.CreatedBy = objPublisher.CreatedBy; ;
                            Publisher.CreatedDate = objPublisher.CreatedDate;
                            Publisher.IsRemoved = objPublisher.IsRemoved;
                            Publisher.IID = objPublisher.IID;

                            Publisher.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            Publisher.ModifiedDate = DateTime.Now;

                            _BookPublisherRT.UpdateBookPublisher(Publisher);
                            ClearData();

                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
                else
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/PublisherDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowPublisherData()
        {
            try
            {
                BookPublisher objPublisher = _BookPublisherRT.GetBookPublisherByIID(IID);
                if (objPublisher != null)
                {
                    txtPublisherName.Text = objPublisher.PublisherName;
                    txtAboutPublisher.Text = objPublisher.AboutPublisher;
                    txtHoldImagePath.Text = objPublisher.PublisherLogoUrl;
                    txtAwardAchieved.Text = objPublisher.AwardAchieved;
                 
                    chkIsRemoved.Checked = objPublisher.IsRemoved;
                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(BookPublisher company)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                BookPublisher objCompanyName = (from tr in _BookPublisherRT.GetAllBookPublishers()
                                         where tr.PublisherName == company.PublisherName
                                          select tr).SingleOrDefault();
                if (objCompanyName != null)
                {
                    if (objCompanyName.PublisherName == company.PublisherName)
                    {
                        message = "Publisher name already exists.";
                    }
                }

          
            }

            return message;
        }

        private BookPublisher CreateBookPublisher()
        {
            Session["UserID"] = "1";
            BookPublisher Publisher = new BookPublisher();
            try
            {
                Publisher.PublisherName = txtPublisherName.Text.Trim();
                Publisher.AboutPublisher = txtAboutPublisher.Text.Trim().Replace(Environment.NewLine, "<br/>");
               
                Publisher.AwardAchieved = txtAwardAchieved.Text;
                Publisher.IsRemoved = chkIsRemoved.Checked;
                if (txtHoldImagePath.Text == string.Empty && ImageUpload.HasFile == true)
                {
                    string permanentImagePathToSave = Upload(Publisher.PublisherName).ToString();
                    Publisher.PublisherLogoUrl = permanentImagePathToSave;
                }
                else if (txtHoldImagePath.Text != null && ImageUpload.HasFile == true)
                {
                    string permanentImagePathToSave = Upload(Publisher.PublisherName).ToString();
                    Publisher.PublisherLogoUrl = permanentImagePathToSave;
                }
                else if (txtHoldImagePath.Text != null && ImageUpload.HasFile == false)
                {
                    Publisher.PublisherLogoUrl = txtHoldImagePath.Text;
                }
                else
                {

                    labelMessage.Text = "Please browse image(s)....";
                    labelMessage.ForeColor = System.Drawing.Color.DarkBlue;
                    labelMessage.Focus();

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return Publisher;
        }

        private void ClearData()
        {
            txtPublisherName.Text = string.Empty;
            txtAboutPublisher.Text = string.Empty;

            txtAwardAchieved.Text = string.Empty;
            //chkIsRemoved.Checked=string.Empty.;
        }

        private string Upload(string PublisherName)
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (ImageUpload.HasFile)
                {
                    List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
                    foreach (var file in ImageUpload.PostedFiles)
                    {
                        var tempFilename = Path.GetFileName(PublisherName);

                        if (Session["seTempFileName"] == null)
                        {
                            Session["seTempFileName"] = new List<ImageUrl>();
                        }
                        PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess
                        Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

                        ImageUpload.SaveAs(Server.MapPath("~/Image/PublisherImage/") + tempFilename + Path.GetExtension(ImageUpload.FileName));

                        imageUrl.ImageUrlTemp = "~/Image/PublisherImage/" + tempFilename + Path.GetExtension(ImageUpload.FileName);
                        PicTempFileUrlList.Add(imageUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }

    }
}