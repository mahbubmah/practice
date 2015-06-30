using System.IO;
using BLL.Basic;
using OB.BLL.Basic;
using OB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.Utilities;
using OH.BLL.Basic;
using Utilities;

namespace OB.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private const string sessBookNewsLetter = "seEmailSubscribe";
        private readonly DefaultRT _defaultRt;
        private readonly BookRT _bookRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public Default()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _defaultRt = new DefaultRT();
            _bookRt = new BookRT();
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
                    LoadPublisherLogo();
                    LoadCategoryAside();
                    LoadCommingSoonRpt();
                    LoadFavouriteBookRpt();
                    LoadLatestBookRpt();
                    LoadBestSellerBanner();
                    LoadTopFiveLinksList();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadTopFiveLinksList()
        {
            try
            {
                var bookTopChart = _bookRt.GetTopTenFavouriteBooks().Take(5).ToList();
                                            
                rptBookTopChart.DataSource = bookTopChart;
                rptBookTopChart.DataBind();


                var bestOfferTopFiveBooks = _bookRt.GetAllBestOffersBookList().Take(5).ToList();
                rptBestOfferTopFive.DataSource = bestOfferTopFiveBooks;
                rptBestOfferTopFive.DataBind();

                var mostVisitedBooks = _bookRt.GetAllMostViewedBookList().Take(5).ToList();
                rptMostViewedTopFive.DataSource = mostVisitedBooks;
                rptMostViewedTopFive.DataBind();
                

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadBestSellerBanner()
        {
            try
            {
                if (_bookRt.GetAllMostViewedBookList().Any())
                {
                    var bestSellerTopTenBooks = (from book in _bookRt.GetAllMostViewedBookList()
                                                where book.IsRemoved == false
                                                select new
                                                {
                                                    book.IID,
                                                    book.BookTitle,
                                                    Abstract = book.Abstract != null ? (book.Abstract.Length > 92 ? book.Abstract.Substring(0, 90) + "..." + "<a target=\"_blank\" href=\"BookDetails?ID="+book.IID+"\"><p>Read more</p></a>" : book.Abstract) : string.Empty,
                                                    book.ImageUrl,
                                                    book.AvgRating,
                                                    book.Price,
                                                    book.NumberOfUsersRate,
                                                    book.BookAuthor.AuthorName,
                                                    book.AuthorID
                                                    
                                                }).Take(10);

                    var bsTopOne = bestSellerTopTenBooks.FirstOrDefault();
                    lblBsActiveBookName.Text = bsTopOne.BookTitle;
                    lblBsActiveAuthorName.Text = bsTopOne.AuthorName;
                    ancBsActiveBookName.HRef = "BookDetails?ID=" + bsTopOne.IID;
                    ancBsActiveBookLink1.HRef = "BookDetails?ID=" + bsTopOne.IID;
                    ancBsActiveAuthorLink.HRef = "AuthBiographyPage?ID=" + bsTopOne.AuthorID;
                    lblBsActiveAbstruct.Text = bsTopOne.Abstract;
                    imgBsActiveBookImage.ImageUrl = bsTopOne.ImageUrl;

                    rptBsBookSlide.DataSource = bestSellerTopTenBooks.Skip(1);
                    rptBsBookSlide.DataBind();
                }
               
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadCommingSoonRpt()
        {
            try
            {
                if (_bookRt.GetTopTenComingSoonBooks().Any())
                {
                    var comingSoonTopTenBook = (from book in _bookRt.GetTopTenComingSoonBooks()
                                                select new
                                                {
                                                    book.IID,
                                                    book.BookTitle,
                                                    Abstract = book.Abstract != null ? (book.Abstract.Length > 92 ? book.Abstract.Substring(0, 90) + "..." + "<a target=\"_blank\" href=\"BookDetails?ID=" + book.IID + "\"><p>Read more</p></a>" : book.Abstract) : string.Empty,
                                                    book.ImageUrl,
                                                    book.AvgRating,
                                                    book.Price,
                                                    book.NumberOfUsersRate,
                                                    book.AuthorID
                                                }).ToList();

                    rptComingSoonActiveSlide.DataSource = comingSoonTopTenBook.Take(2);
                    rptComingSoonSlide.DataSource = comingSoonTopTenBook.Skip(2).Take(2);
                    rptComingSoonActiveSlide.DataBind();
                    rptComingSoonSlide.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadLatestBookRpt()
        {
            try
            {
                if (_bookRt.GetTopTenLatestBooks().Any())
                {
                    var latestTopTenBook = (from book in _bookRt.GetTopTenLatestBooks()
                                            select new
                                            {
                                                book.IID,
                                                book.BookTitle,
                                                Abstract = book.Abstract != null ? (book.Abstract.Length > 92 ? book.Abstract.Substring(0, 90) + "..." + "<a target=\"_blank\" href=\"BookDetails?ID=" + book.IID + "\"><p>Read more</p></a>" : book.Abstract) : string.Empty,
                                                book.ImageUrl,
                                                book.AvgRating,
                                                book.Price,
                                                book.NumberOfUsersRate,
                                                book.AuthorID
                                            }).ToList();
                    rptLatestActiveSlide.DataSource = latestTopTenBook.Take(2);
                    rptLatestSlide.DataSource = latestTopTenBook.Skip(2).Take(2);
                    rptLatestActiveSlide.DataBind();
                    rptLatestSlide.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadFavouriteBookRpt()
        {
            try
            {
                if (_bookRt.GetTopTenFavouriteBooks().Any())
                {
                    var favouriteTopTenBook = (from book in _bookRt.GetTopTenFavouriteBooks()
                                               select new
                                               {
                                                   book.IID,
                                                   book.BookTitle,
                                                   Abstract = book.Abstract != null ? (book.Abstract.Length > 92 ? book.Abstract.Substring(0, 90) + "..." + "<a target=\"_blank\" href=\"BookDetails?ID=" + book.IID + "\"><p>Read more</p></a>" : book.Abstract) : string.Empty,
                                                   book.ImageUrl,
                                                   book.AvgRating,
                                                   book.Price,
                                                   book.NumberOfUsersRate,
                                                   book.AuthorID
                                               }).ToList();

                    rptFavouriteActiveSlide.DataSource = favouriteTopTenBook.Take(2);
                    rptFavouriteSlide.DataSource = favouriteTopTenBook.Skip(2).Take(2);
                    rptFavouriteActiveSlide.DataBind();
                    rptFavouriteSlide.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    
        private void LoadCategoryAside()
        {
            try
            {
                var bookCatList = (from cat in _defaultRt.GetBookCatListForDefaultAside() select new
                {
                    cat.IID,
                    cat.CategoryName,
                    cat.ImageUrl,
                    catLink = cat.ParentCategoryID == Convert.ToInt32(EnumCollection.ParentCategory.Fiction) ? "BookFiction?Tp=" : "BookNonFiction?Tp="
                }).Take(6).ToList();
                
                rptBookCategoryAside.DataSource = bookCatList;
                rptBookCategoryAside.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadPublisherLogo()
        {
            try
            {
                BookPublisherRT _BookPublisherRT = new BookPublisherRT();
                var objPub = _BookPublisherRT.GetAllLogo().Take(4).ToList();
                if (objPub.Count > 0)
                {
                    rpPublisher.DataSource = objPub;
                    rpPublisher.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpPublisher_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Image objImage = ((Image)e.Item.FindControl("img_PublisherLogo"));
                    if (!string.IsNullOrEmpty(objImage.ImageUrl.ToString()))
                    {
                        objImage.ImageUrl = objImage.ImageUrl.ToString();
                        objImage.Width = 80;
                        objImage.Height = 75;
                    }

                    //Literal objltrTitle = (Literal)e.Item.FindControl("ltrPublisherName");


                    //objltrTitle.Text = objltrTitle.Text;

                    //Literal objltrDescription = (Literal)e.Item.FindControl("ltrForSaleDescription");
                    //if (objltrDescription.Text.Length > 25)
                    //{
                    //    var text = objltrDescription.Text.Substring(0, 25);
                    //    objltrDescription.Text = text;
                    //    // objltrDescription.Text = text.Substring(0,text.LastIndexOf(" "));
                    //}
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private BookNewsLetter CreateBookLetter()
        {
            Session["UserID"] = "1";
            BookNewsLetter BookLetter = new BookNewsLetter();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    //BookLetter.IID = Convert.ToInt32(hdEmailID.Value.ToString());
                    BookNewsLetterRT receiverTransfer = new BookNewsLetterRT();
                    BookNewsLetter emailSubscription = receiverTransfer.GetEmailSubscribrIDByEmail(txtEmailAdd.Text);
                    Session[sessBookNewsLetter] = emailSubscription;
                    // OiiONewsLetter EmailSubscribe = (OiiONewsLetter)Session[sessEmailSubscribe];
                    BookLetter.IID = emailSubscription.IID;
                }
                BookLetter.UserEmail = txtEmailAdd.Text.Trim();
                BookLetter.SubscribeDate = DateTime.Now;

                if (BookLetter.IID <= 0)
                {
                    BookLetter.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    BookLetter.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    //OiiOOther Oiioother = (OiiOOther)Session[sessOtherContent];
                    BookNewsLetter letter = (BookNewsLetter)Session[sessBookNewsLetter];
                    BookLetter.CreatedBy = letter.CreatedBy; ;
                    BookLetter.CreatedDate = letter.CreatedDate;
                    BookLetter.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    BookLetter.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsEdit.Value != "true")
                {
                    BookLetter.IsSubscribe = true;
                }
                else
                {
                    BookLetter.IsSubscribe = false;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return BookLetter;

        }

        protected void btn_subscribe_Click(object sender, EventArgs e)
        {
            try
            {
                lblEmailSubscribe.Text = string.Empty;

                using (BookNewsLetterRT receiverTransfer = new BookNewsLetterRT())
                {
                    List<BookNewsLetter> BookList = new List<BookNewsLetter>();
                    BookList = receiverTransfer.GetLetterListByEmail(txtEmailAdd.Text);
                    if (BookList != null && BookList.Count > 0)
                    {
                        string msg = "Email ::  " + txtEmailAdd.Text + " Already Subscribed!";
                        lblEmailSubscribe.Text = msg;
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    //hdSave.Value = "true";
                    BookNewsLetter letter = CreateBookLetter();
                    receiverTransfer.AddBookLetter(letter);
                    if (letter.IID > 0)
                    {
                        lblEmailSubscribe.Text = "User successfully Subscribed...";
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblEmailSubscribe.Text = "Data not saved...";
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
    }
}