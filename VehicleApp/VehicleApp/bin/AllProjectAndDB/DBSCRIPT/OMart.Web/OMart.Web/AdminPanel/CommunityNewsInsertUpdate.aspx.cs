using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL.Basic;
using System.Text;
using System.Globalization;
using System.IO;
using Utilities;
using BLL;

namespace OMart.Web.AdminPanel
{
    public partial class CommunityNewsInsertUpdate : System.Web.UI.Page
    {
        private readonly CommunityNewsRT _CommunityNewsRT;
        private long IID = default(Int64);


        int lvRowCount = 0;
        int currentPage = 0;
        public CommunityNewsInsertUpdate()
        {
            this._CommunityNewsRT = new CommunityNewsRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownNewsType(null);

                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowCommunityNewsData();

                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #region private methods

        #region load dropdown
        private void LoadDropDownNewsType(int? comID)
        {
            try
            {
                DropDownListHelper.Bind(dropdownNewsType, EnumHelper.EnumToList<EnumCollection.NewsType>(), EnumCollection.ListItemType.NewsType);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion load dropdown
        private bool TextControlCheckBeforeSave()
        {
            bool mandatoryFieldHasData = true;


            if (txtHeadLine.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " News Headlines is required..?";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            if (txtNewsDescription.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " News Description is required?";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }
            if (dropdownNewsType.Text.Trim() == "-1")
            {
                labelMessage.Text = " News Type is required..?";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            return mandatoryFieldHasData;
        }


        private void ShowCommunityNewsData()
        {
            try
            {
                CommunityNew _CommunityNews = _CommunityNewsRT.GetCommunityNewsByIID(IID);
                if (_CommunityNews != null)
                {
                    dropdownNewsType.SelectedValue = _CommunityNews.NewsTypeID.ToString();

                    txtHeadLine.Text = _CommunityNews.HeadLine != null ? _CommunityNews.HeadLine.ToString() : string.Empty;
                    txtNewsDescription.Text = _CommunityNews.NewsDescription != null ? _CommunityNews.NewsDescription.ToString() : string.Empty;
                    txtRedirectUrl.Text = _CommunityNews.VideoLink != null ? _CommunityNews.VideoLink.ToString() : string.Empty;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(CommunityNew _CommunityNew)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                CommunityNew objCommunityNew = (from tr in _CommunityNewsRT.GetAllCommunityNews()
                                                where tr.IID == _CommunityNew.IID
                                                select tr).SingleOrDefault();
                if (objCommunityNew != null)
                {
                    if (objCommunityNew.IID == _CommunityNew.IID)
                    {
                        message = "Already exists.";
                    }
                }


            }

            return message;
        }

        private CommunityNew CreateCommunityNews()
        {
            CommunityNew _CommunityNews = new CommunityNew();
            try
            {
                if (string.IsNullOrEmpty(dropdownNewsType.SelectedValue))
                {
                    labelMessage.Text = "Please Select News Type";
                    return null;
                }

                _CommunityNews.NewsTypeID = Convert.ToInt32(dropdownNewsType.SelectedValue);

                _CommunityNews.PublishDate = GlobalRT.GetServerDateTime();
                switch (Convert.ToInt32(dropdownNewsType.SelectedValue))
                {
                    case 1:
                        _CommunityNews.NewsType = "Education";
                        break;
                    case 2:
                        _CommunityNews.NewsType = "Recreation";
                        break;
                    case 3:
                        _CommunityNews.NewsType = "Sports";
                        break;
                    case 4:
                        _CommunityNews.NewsType = "Popular Guide";
                        break;

                }
                _CommunityNews.HeadLine = txtHeadLine.Text.Trim();
                _CommunityNews.NewsDescription = txtNewsDescription.Text.Trim();
                _CommunityNews.VideoLink = txtRedirectUrl.Text.Trim();
                _CommunityNews.IsRemoved = false;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return _CommunityNews;
        }

        private void ClearData()
        {

            txtHeadLine.Text = string.Empty;
            dropdownNewsType.SelectedValue = "-1";
            txtNewsDescription.Text = string.Empty;
            txtRedirectUrl.Text = string.Empty;
        }
        #endregion private

        #region protected
        private string Upload()
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (PictureUpload.HasFile)
                {
                    List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
                    foreach (var file in PictureUpload.PostedFiles)
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

                        var tempImageName = now;

                        var tempFilename = Path.GetFileName(tempImageName + "__" + PictureUpload.FileName);


                        if (Session["seTempFileName"] == null)
                        {
                            Session["seTempFileName"] = new List<ImageUrl>();
                        }
                        PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess


                        Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

                        PictureUpload.SaveAs(Server.MapPath("~/All Photos/CommunityNews/") + tempFilename);

                        imageUrl.ImageUrlTemp = "~/All Photos/CommunityNews/" + tempFilename;
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

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TextControlCheckBeforeSave())
                {
                    return;
                }
                CommunityNew _CommunityNew = CreateCommunityNews();
                if (_CommunityNew == null)
                {
                    return;
                }
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

                ImageUrl imageUrl = new ImageUrl();
                if (PictureUpload.HasFile)
                {
                    string permanentImagePathToSave = Upload().ToString();
                    _CommunityNew.Image = permanentImagePathToSave;
                }
                else
                {
                    var news = _CommunityNewsRT.GetCommunityNewsByIID(IID);
                    if (news!=null)
                    {
                        _CommunityNew.Image=news.Image;
                    }
                }

                var msg = BusinessLogicValidation(_CommunityNew);


                if (string.IsNullOrEmpty(msg))
                {

                    if (IID <= 0)
                    {
                        _CommunityNew.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        _CommunityNew.CreatedDate = DateTime.Now;

                        _CommunityNewsRT.AddCommunityNews(_CommunityNew);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        CommunityNew objCommunityNew = _CommunityNewsRT.GetCommunityNewsByIID(IID);

                        if (objCommunityNew != null)
                        {
                            if (_CommunityNew.Image == null)
                            {
                                _CommunityNew.Image = objCommunityNew.Image;
                            }
                            _CommunityNew.CreatedBy = objCommunityNew.CreatedBy; ;
                            _CommunityNew.CreatedDate = objCommunityNew.CreatedDate;
                            _CommunityNew.IID = objCommunityNew.IID;

                            _CommunityNew.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            _CommunityNew.ModifiedDate = DateTime.Now;

                            _CommunityNewsRT.UpdateCommunityNews(_CommunityNew);
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
                Response.Redirect("~/AdminPanel/CommunityNewsDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion protected
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }

    }
}