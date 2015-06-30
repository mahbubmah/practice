using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using OB.DAL;
using Utilities;

namespace OB.Web
{
    public partial class AuthBookList : System.Web.UI.Page
    {
        private readonly BookRT _bookRt;
        private long IID = default(Int64);
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public AuthBookList()
        {
            _bookRt=new BookRT();
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
                var reqId = Request.QueryString["AuthId"];
                bool isAuthIdValid = Int64.TryParse(reqId, out IID);
                if (isAuthIdValid)
                {
                    LoadBookListByAuthor();
                }
               
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadBookListByAuthor()
        {
            try
            {
              var bookListByAuthId= from book in _bookRt.GetAllBooksByAuthorId(IID)
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
                rptAuthBookList.DataSource = bookListByAuthId;
                rptAuthBookList.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
             
        }
    }
}