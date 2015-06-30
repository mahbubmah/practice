using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using OB.DAL;
using OB.Utilities;
using Utilities;

namespace OB.Web
{
    public partial class TopBooks : System.Web.UI.Page
    {
        private readonly BookRT _bookRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public TopBooks()
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
                 //   ActiveBookType();
                    LoadBooks();
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void ActiveBookType()
        {
            try
            {
                //if (Convert.ToInt32(Request.QueryString["TypeId"]) == Convert.ToInt32(EnumCollection.BestBooksCatType.Best_Offer))
                //{
                //    liTabMostFav.Attributes.Remove("class");
                //    liTabBestOffer.Attributes.Add("class", "active");
                //}
                //else if (Convert.ToInt32(Request.QueryString["TypeId"]) == Convert.ToInt32(EnumCollection.BestBooksCatType.Best_Authors))
                //{
                //    liTabMostFav.Attributes.Remove("class");
                //    liTabBestAuthors.Attributes.Add("class", "active");


                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var mostFavBooks = from book in _bookRt.GetAllMostFavouriteBookList()
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

                rptBestSellerBooks.DataSource = mostFavBooks;
                rptBestSellerBooks.DataBind();

                var bestAuthors = from author in _bookRt.GetAllBestAuthors()
                                  select new
                                      {
                                          author.AuthorName,
                                          CountryName = author.Country.Name,
                                          author.IID,
                                          author.Picture,
                                          author.FavouriteQuote,
                                          AboutAuthor = author.AboutAuthor != null ? (author.AboutAuthor.Length > 92 ? author.AboutAuthor.Substring(0, 90) + "..." : author.AboutAuthor) : string.Empty,
                                      };
                rptBestAuthors.DataSource = bestAuthors;
                rptBestAuthors.DataBind();

                var bestOfferBooks = from book in _bookRt.GetAllBestOffersBookList()
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
                rptBestOfferBooks.DataSource = bestOfferBooks;
                rptBestOfferBooks.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}