using System.Data.Common;
using System.IO;
using System.Xml.Linq;
using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.DAL;
using OH.BLL.Basic;
using Utilities;

namespace OB.Web
{
    public partial class AuthBiographyPage : System.Web.UI.Page
    {
        private long IID = default(Int64);
        private readonly BookRT _bookRt;
        private readonly BookAuthorRT _bookAuthorRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public AuthBiographyPage()
        {
            _bookAuthorRt = new BookAuthorRT();
            _bookRt = new BookRT();
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
                    var authId = Int64.TryParse(Request.QueryString["ID"], out IID);
                    if (authId)
                    {
                        LoadBookByAuthor();
                    }
                    
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        


        private void LoadBookByAuthor()
        {
            try
            {
                var bookList =
                    _bookRt.GetAllBooksByAuthorId(IID)
                        .OrderByDescending(x => x.TotalVisit)
                        .ThenBy(x => x.AvgRating);
                var bookAuther = _bookAuthorRt.GetBookAuthorByIID(IID);

                imgAuthImage.ImageUrl = bookAuther.Picture;
                lbAboutAuthor.Text = bookAuther.AboutAuthor;
                lbAuthName.Text = bookAuther.AuthorName;
                lbAuthWebsiteLink.Text = bookAuther.WebsiteLink;
                lbAuthName1.Text = bookAuther.AuthorName;
                ancAuthWebLink.HRef = bookAuther.WebsiteLink;
                lbAuthWebsiteName.Text = bookAuther.WebsiteLink;
                rptBook.DataSource = bookList.Take(4).ToList();
                rptBook.DataBind();


                ltrAuthorName.Text = bookAuther.AuthorName;
                ltrCount.Text = bookAuther.AuthorName + " has written" + _bookRt.GetAllBooksByAuthorId(IID).Count().ToString() + " books";
                lbBrowseAuthorAllBooks.Text = "Browse all books of " + bookAuther.AuthorName;




            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lbBrowseAuthorAllBooks_OnClick(object sender, EventArgs e)
        {
            try
            {
                var authId = Int64.TryParse(Request.QueryString["ID"], out IID);
                if (authId)
                {
                    Response.Redirect("AuthBookList?AuthId=" + IID, false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}