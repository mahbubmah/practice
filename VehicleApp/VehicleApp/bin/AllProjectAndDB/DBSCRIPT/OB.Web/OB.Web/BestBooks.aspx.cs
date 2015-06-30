using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using Utilities;

namespace OB.Web
{
    public partial class BestBooks : System.Web.UI.Page
    {
        private readonly BookRT _bookRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public BestBooks()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._bookRt = new BookRT();
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
                LoadBooks();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var recBooks = from book in _bookRt.GetAllRecommandedBookList()
                               select new
                                   {
                                       book.IID,
                                       book.BookAuthor.AuthorName,
                                       book.BookTitle,
                                       Abstract = book.Abstract != null ? (book.Abstract.Length > 92 ? book.Abstract.Substring(0, 90) + "..." : book.Abstract) : string.Empty,
                                       book.AvgRating,
                                       book.ImageUrl,
                                       book.Price,
                                       book.NumberOfUsersRate,
                                       book.AuthorID
                                   };

                rptRecommendedBooks.DataSource = recBooks;
                rptRecommendedBooks.DataBind();


                var latestBooks = from book in _bookRt.GetAllLatestBookList()
                                  select new
                                  {
                                      book.IID,
                                      book.BookAuthor.AuthorName,
                                      book.BookTitle,
                                      Abstract = book.Abstract != null ? (book.Abstract.Length > 92 ? book.Abstract.Substring(0, 90) + "..." : book.Abstract) : string.Empty,
                                      book.AvgRating,
                                      book.ImageUrl,
                                      book.Price,
                                      book.NumberOfUsersRate,
                                      book.AuthorID
                                  };

                rptRecommendedBooks.DataSource = latestBooks;
                rptRecommendedBooks.DataBind();


                var comingSoonBooks = from book in _bookRt.GetAllComingSoonBookList()
                                      select new
                                         {
                                             book.IID,
                                             book.BookAuthor.AuthorName,
                                             book.BookTitle,
                                             Abstract = book.Abstract != null ? (book.Abstract.Length > 92 ? book.Abstract.Substring(0, 90) + "..." : book.Abstract) : string.Empty,
                                             book.AvgRating,
                                             book.ImageUrl,
                                             book.Price,
                                             book.NumberOfUsersRate,
                                             book.AuthorID
                                         };
                rptComingSoonBooks.DataSource = comingSoonBooks;
                rptComingSoonBooks.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}