using System.IO;
using BLL.Basic;
using OB.BLL.Basic;
using OB.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OB.Web
{
    public partial class BookNonFiction : System.Web.UI.Page
    {
        private long IID = default(Int64);
        Int64 Iid = default(Int64);
        string EncryptedID = default(string);
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public BookNonFiction()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");

                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Tp"]))
                {
                    string EncryptedID = Request.QueryString["Tp"];
                    Int64 DecrptedIid = Convert.ToInt64(StringCipher.Decrypt(EncryptedID));
                    Session["detailID"] = DecrptedIid.ToString();
                    bool reqIDIsValid = Int64.TryParse(DecrptedIid.ToString(), out Iid);
                    if (reqIDIsValid)
                    {
                        LoadRecommendedReading(Iid);
                        LoadLatestRelease(Iid);
                        LoadFeatureAuthor(Iid);
                        LoadComingSoon(Iid);
                    }
                    else
                    {
                        Response.Redirect("ErrorOccurs.html");
                    }
                }
                else
                {
                    LoadRecommendedReading();
                    LoadLatestRelease();
                    LoadFeatureAuthor();
                    LoadComingSoon();
                }
                LoadCategoryNameDes();
              
                //if (!IsPostBack)
                //{
                //    //IID = Convert.ToInt64(Request.QueryString["Type"]);
                //    LoadCategoryNameDes();
                //    LoadRecommendedReading();
                //    LoadLatestRelease();
                //    LoadFeatureAuthor();
                //    LoadComingSoon();
                //}
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadRecommendedReading(Int64 Iid)
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objPub = _BookRT.GetAllFictionCategoryBookByCategoryID(Iid);
                if (objPub != null)
                {
                    rpNonFictionBook.DataSource = objPub;
                    rpNonFictionBook.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadRecommendedReading()
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objPub = _BookRT.GetAllNonFictionCategoryBook(Convert.ToInt32(EnumCollection.ParentCategory.Non_Fiction));
                if (objPub != null)
                {
                    rpNonFictionBook.DataSource = objPub;
                    rpNonFictionBook.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpNonFictionBook_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrTitle = (Literal)e.Item.FindControl("ltrAuthorName");
                    objltrTitle.Text = objltrTitle.Text;

                    Literal objltrbookTitle = (Literal)e.Item.FindControl("ltrBookTitle");
                    objltrbookTitle.Text = objltrbookTitle.Text;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadLatestRelease(Int64 Iid)
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objPub = _BookRT.GetAllFictionCategoryLatestBookByCategoryID(Iid);
                if (objPub != null)
                {
                    rpLatest.DataSource = objPub;
                    rpLatest.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadLatestRelease()
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objPub = _BookRT.GetAllNonFictionCategoryLatestBook(IID);
                if (objPub != null)
                {
                    rpLatest.DataSource = objPub;
                    rpLatest.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpLatest_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrTitle = (Literal)e.Item.FindControl("ltrAuthorName");
                    objltrTitle.Text = objltrTitle.Text;

                    Literal objltrbookTitle = (Literal)e.Item.FindControl("ltrBookTitle");
                    objltrbookTitle.Text = objltrbookTitle.Text;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadFeatureAuthor()
        {
            try
            {
                BookAuthorRT _BookAuthorRT = new BookAuthorRT();
                var objFauthor = _BookAuthorRT.GetOneFeaturedAuthor();
                if (objFauthor != null)
                {
                    rpFAuthor.DataSource = objFauthor;
                    rpFAuthor.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadFeatureAuthor(Int64 Iid)
        {
            try
            {
                BookAuthorRT _BookAuthorRT = new BookAuthorRT();
                var objFauthor = _BookAuthorRT.GetOneFeaturedAuthorBycategory(Iid);
                if (objFauthor != null)
                {
                    rpFAuthor.DataSource = objFauthor;
                    rpFAuthor.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void rpFAuthor_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrAuthorName = (Literal)e.Item.FindControl("ltrAuthorName");
                    objltrAuthorName.Text = objltrAuthorName.Text;

                    Literal objltrbookTitle = (Literal)e.Item.FindControl("ltrFavQuote");
                    objltrbookTitle.Text = objltrbookTitle.Text;
                    Literal objltrAuthor = (Literal)e.Item.FindControl("ltrAuthor");
                    objltrAuthor.Text = objltrAuthor.Text;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadCategoryNameDes()
        {
            try
            {
                //BookCategoryRT _BookCategoryRT = new BookCategoryRT();
                //string obj = _BookCategoryRT.GetCategoryDes(2);
                //if (obj != null)
                //{
                //    ltrDes.Text = obj.ToString();

                //}
                string fictionTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.ParentCategory>(Convert.ToInt32(EnumCollection.ParentCategory.Non_Fiction));
                ltrFictionTypeName.Text = fictionTypeName;

                string enumDescription = EnumHelper.GetDescription(EnumCollection.ParentCategory.Non_Fiction);
                if (!string.IsNullOrEmpty(enumDescription))
                {
                    ltrDes.Text = enumDescription;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadComingSoon()
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objComingBooks = _BookRT.GetNonFictionComingSoon();
                if (objComingBooks != null)
                {
                    rpComingSoon.DataSource = objComingBooks;
                    rpComingSoon.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadComingSoon(Int64 Iid)
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objComingBooks = _BookRT.GetFictionComingSoonByID(Iid);
                if (objComingBooks != null)
                {
                    rpComingSoon.DataSource = objComingBooks;
                    rpComingSoon.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void rpComingSoon_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Image objimg_Book = (Image)e.Item.FindControl("img_Book");
                    objimg_Book.ImageUrl = objimg_Book.ImageUrl;

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}