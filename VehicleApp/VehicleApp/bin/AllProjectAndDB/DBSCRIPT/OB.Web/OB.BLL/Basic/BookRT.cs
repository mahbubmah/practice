using OB.DAL;
using OB.DAL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Data;
using OB.Utilities;


namespace BLL.Basic
{
    public class BookRT : IDisposable
    {

        private readonly OiiOBookDCDataContext _dbContext;
        public BookRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddBook(Book _Book)
        {
            try
            {
                DatabaseHelper.Insert<Book>(_Book);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateBook(Book _Book)
        {
            try
            {
                Book mobileNew = _dbContext.Book.SingleOrDefault(d => d.IID == _Book.IID);

                DatabaseHelper.Update<Book>(_dbContext, _Book, mobileNew);

                //_dbContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateBookAndBookFeature(Book _Book, List<BookOtherStoreUrl> list)
        {
            try
            {
                Book bookNew = _dbContext.Book.SingleOrDefault(d => d.IID == _Book.IID);

                DatabaseHelper.Update<Book>(_dbContext, _Book, bookNew);

                _dbContext.SP_DeleteBookFeatureBYBooKIID(_Book.IID);

                foreach (BookOtherStoreUrl feature in list)
                {
                    BookOtherStoreUrl fe = new BookOtherStoreUrl();
                    fe.BookID = _Book.IID;
                    DatabaseHelper.Insert<BookOtherStoreUrl>(fe);
                }

                //_dbContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //mahbub
        #region IQueryable best books
        public IQueryable<Book> GetAllMostFavouriteBookList()
        {
            try
            {
                var favBookList =
                    _dbContext.Book.OrderByDescending(x => x.AvgRating)
                        .ThenByDescending(x => x.NumberOfUsersRate);
                return favBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllBestOffersBookList()
        {
            try
            {
                var bestOfferBookList =
                    _dbContext.Book.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Discount).ThenBy(x => x.VAT);
                return bestOfferBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<BookAuthor> GetAllBestAuthors()
        {
            try
            {
                var bestAuthorsList = _dbContext.Book.OrderByDescending(x => x.TotalVisit).GroupBy(x => x.AuthorID).Select(g => g.First()).Select(bookAu => bookAu.BookAuthor);
                return bestAuthorsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public BookAuthor GetFeaturedAuthor()
        {
            try
            {
                var featuredAuthor = _dbContext.Book.Where(x => x.BookAuthor.IsFeatured == true).OrderByDescending(x => x.AvgRating).ThenByDescending(x => x.TotalVisit).FirstOrDefault().BookAuthor;

                return featuredAuthor;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }//done
        public BookAuthor GetFicFeaturedAuthor()
        {
            try
            {
                var ficFeaturedAuthor = _dbContext.Book.Where(x => x.BookAuthor.IsFeatured == true && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Fiction)).OrderByDescending(x => x.AvgRating).ThenByDescending(x => x.TotalVisit).FirstOrDefault().BookAuthor;
                return ficFeaturedAuthor;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }//done
        public BookAuthor GetNonFicFeaturedAuthor()
        {
            try
            {
                var nonFicFeaturedAuthor = _dbContext.Book.Where(x => x.BookAuthor.IsFeatured == true && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Non_Fiction)).OrderByDescending(x => x.AvgRating).ThenByDescending(x => x.TotalVisit).FirstOrDefault().BookAuthor;
                return nonFicFeaturedAuthor;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }//done

        public IQueryable<Book> GetAllComingSoonBookList()
        {
            try
            {
                DateTime newestDate = DateTime.Now.AddDays(90);
                var comingSoonBook = from book in _dbContext.Book.Where(x => x.IsRemoved == false).OrderBy(x => x.BookTitle)
                                     where book.IsRemoved == false
                                           && book.PublishedDate <= newestDate
                                           && book.PublishedDate >= DateTime.Now
                                     select book;
                return comingSoonBook;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllFicComingSoonBookList()
        {
            try
            {
                DateTime newestDate = DateTime.Now.AddDays(90);
                var comingSoonBook = from book in _dbContext.Book.Where(x => x.IsRemoved == false && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Fiction)).OrderBy(x => x.BookTitle)
                                     where book.IsRemoved == false
                                           && book.PublishedDate <= newestDate
                                           && book.PublishedDate >= DateTime.Now
                                     select book;
                return comingSoonBook;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllNonFicComingSoonBookList()
        {
            try
            {
                DateTime newestDate = DateTime.Now.AddDays(90);
                var comingSoonBook = from book in _dbContext.Book.Where(x => x.IsRemoved == false && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Non_Fiction)).OrderBy(x => x.BookTitle)
                                     where book.IsRemoved == false
                                           && book.PublishedDate <= newestDate
                                           && book.PublishedDate >= DateTime.Now
                                     select book;
                return comingSoonBook;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllMostViewedBookList()
        {
            try
            {
                var mostViewedBookList = _dbContext.Book.Where(x => x.IsRemoved == false).OrderByDescending(x => x.TotalVisit);
                return mostViewedBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done

        public IQueryable<Book> GetAllLatestBookList()
        {
            try
            {
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0, 0));
                var latestBookList = from book in _dbContext.Book.Where(x => x.IsRemoved == false).OrderBy(x => x.BookTitle)
                                     where book.PublishedDate >= oldestDate
                                           && book.PublishedDate <= DateTime.Now
                                           && book.IsLatest
                                     select book;
                return latestBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllFicLatestBookList()
        {
            try
            {
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0, 0));
                var latestFicBookList = from book in _dbContext.Book.Where(x => x.IsRemoved == false && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Fiction)).OrderBy(x => x.BookTitle)
                                        where book.PublishedDate >= oldestDate
                                              && book.PublishedDate <= DateTime.Now
                                              && book.IsLatest
                                        select book;
                return latestFicBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllNonFicLatestBookList()
        {
            try
            {
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0, 0));
                var latestFicBookList = from book in _dbContext.Book.Where(x => x.IsRemoved == false && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Non_Fiction)).OrderBy(x => x.BookTitle)
                                        where book.PublishedDate >= oldestDate
                                              && book.PublishedDate <= DateTime.Now
                                              && book.IsLatest
                                        select book;
                return latestFicBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done

        public IQueryable<Book> GetAllRecommandedBookList()
        {
            try
            {
                var recommandedBookList =
                    _dbContext.Book.Where(x => x.IsRemoved == false && x.IsRecommended)
                        .OrderByDescending(x => x.TotalVisit);
                return recommandedBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllFicRecommandedBookList()
        {
            try
            {
                var recommandedFicBookList =
                   _dbContext.Book.Where(x => x.IsRemoved == false && x.IsRecommended && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Fiction))
                       .OrderByDescending(x => x.TotalVisit);
                return recommandedFicBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        public IQueryable<Book> GetAllNonFicRecommandedBookList()
        {
            try
            {
                var recommandedNonFicBookList =
                   _dbContext.Book.Where(x => x.IsRemoved == false && x.IsRecommended && x.BooKCategory.ParentCategoryID == Convert.ToInt16(EnumCollection.ParentCategory.Non_Fiction))
                       .OrderByDescending(x => x.TotalVisit);
                return recommandedNonFicBookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }//done
        #endregion IQueryable best books



        public Book GetBookByIID(Int64 bookID)
        {
            try
            {
                Book mobilephoneID = _dbContext.Book.SingleOrDefault(d => d.IID == bookID);
                //_dbContext.Dispose();
                return mobilephoneID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BookOtherStoreUrl> GetBooksFeatureByBookID(Int64 bookIID)
        {
            try
            {
                List<BookOtherStoreUrl> featureList = _dbContext.BookOtherStoreUrls.OrderBy(x => x.BookID == bookIID).ToList();

                return featureList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                List<Book> bookID = _dbContext.Book.OrderBy(x => x.BookTitle).ToList();

                return bookID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BookInformation> GetAllBookInforrmations()
        {
            try
            {
                List<BookInformation> _BookrmationDisplayList = new List<BookInformation>();
                var bookList = _dbContext.SP_GetAllbookInfoForListView().ToList();
                foreach (var book in bookList)
                {
                    var bookDisplay = new BookInformation();
                    bookDisplay.IID = book.IID;
                    bookDisplay.CategoryName = book.CategoryName;
                    bookDisplay.AuthorName = book.AuthorName;
                    bookDisplay.PublisherName = book.PublisherName;
                    bookDisplay.Abstract = book.Abstract;
                    bookDisplay.BookTitle = book.BookTitle;
                    bookDisplay.Discount = book.Discount;
                    bookDisplay.Edition = book.Edition;
                    bookDisplay.ImageUrl = book.ImageUrl;
                    bookDisplay.ISBN = book.ISBN;
                    bookDisplay.PublishedDate = book.PublishedDate;
                    bookDisplay.LastVisibilityDate = book.LastVisibilityDate;
                    bookDisplay.Quantity = book.Quantity;
                    bookDisplay.IsLatest = book.IsLatest;
                    bookDisplay.IsRecommended = book.IsRecommended;
                    bookDisplay.IsRemoved = book.IsRemoved;

                    bookDisplay.Price = book.Price;
                    bookDisplay.VAT = book.VAT;


                    switch (book.ParentCategoryID)
                    {
                        case 1:
                            bookDisplay.ParentCategory = "Fiction";
                            break;
                        case 2:
                            bookDisplay.ParentCategory = "Non_Fiction";
                            break;
                    }
                    _BookrmationDisplayList.Add(bookDisplay);
                }
                return _BookrmationDisplayList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
        public class BookInformation
        {
            public Int64 IID { get; set; }

            public string CategoryName { get; set; }
            public string BookTitle { get; set; }
            public string ParentCategory { get; set; }
            public string PublisherName { get; set; }
            public string AuthorName { get; set; }
            public string BookWishType { get; set; }
            public int? VAT { get; set; }
            public int? Rating { get; set; }
            public int? ISBN { get; set; }
            public string Abstract { get; set; }
            public string Edition { get; set; }
            public string Size { get; set; }
            public int? Quantity { get; set; }
            public string Version { get; set; } public int? Discount { get; set; }
            public string BookAvailableUrl { get; set; }
            public string ImageUrl { get; set; }
            public DateTime? PublishedDate { get; set; }
            public DateTime? LastVisibilityDate { get; set; }

            public decimal? Price { get; set; }

            public bool? IsLatest { get; set; }    public bool? IsRecommended { get; set; }
            public bool? IsRemoved { get; set; }

        }
        public object GetAllFictionCategoryBook()
        {
            var FictionCategoryBook = from book in _dbContext.Book
                                      join author in _dbContext.BookAuthors
                                      on book.AuthorID equals author.IID
                                      where book.CategoryID == Convert.ToInt64(OB.Utilities.EnumCollection.ParentCategory.Fiction) && book.IsRecommended == true
                                      select new
                                      {
                                          book.IID,
                                          book.ImageUrl,
                                          author.AuthorName,
                                          AuthorID=author.IID,
                                          book.BookTitle,
                                          book.Abstract

                                      };
            return FictionCategoryBook.ToList().Take(3);

        }
        /// <summary>
        /// Get data FictionCategory by Hasan 2015.06.01
        /// </summary>
        /// 
        public object GetAllFictionCategoryBook(int fictionTypeID)
        {
            var FictionCategoryBook = from book in _dbContext.Book
                                      join author in _dbContext.BookAuthors
                                      on book.AuthorID equals author.IID
                                      where book.CategoryID == fictionTypeID && book.IsRecommended == true
                                      select new
                                      {
                                          book.IID,
                                          book.ImageUrl,
                                          author.AuthorName,
                                          book.BookTitle,
                                          book.Abstract

                                      };
            return FictionCategoryBook.ToList().Take(3);

        }
        public class BookDetails
        {
            public Int64 IID { get; set; }
            public Int64? AuthorID { get; set; }
            public string AuthorName { get; set; }
            public string AboutAuthor { get; set; }
            public string AuthorImage { get; set; }
            public string BookTitle { get; set; }
            public string PublisherName { get; set; }
            public string Abstract { get; set; }
            public string ImageUrl { get; set; }
            public int? BookWishType { get; set; }
        }

        public List<BookDetails> GetAllBookForDetails()
        {
            var detailBook = (from book in _dbContext.Book
                              join author in _dbContext.BookAuthors
                              on book.AuthorID equals author.IID
                              join publisher in _dbContext.BookPublishers
                              on book.PublisherID equals publisher.IID
                              where book.IsRemoved == false
                              select new BookDetails
                              {
                                  IID = book.IID,
                                  ImageUrl = book.ImageUrl,
                                  AuthorName = author.AuthorName,
                                  AuthorImage = author.Picture,
                                  AboutAuthor = author.AboutAuthor,
                                  AuthorID = book.AuthorID,
                                  BookTitle = book.BookTitle,
                                  PublisherName = publisher.PublisherName,
                                  Abstract = book.Abstract,
                                  //BookWishType = book.BookWishType

                              }).ToList();
            return detailBook;

        }
        public BookDetails GetBookForDetails(Int64 IID)
        {
            BookDetails detailBook = (from bookDetails in GetAllBookForDetails()
                                      where bookDetails.IID == IID
                                      select bookDetails).SingleOrDefault();
            return detailBook;

        }
        public object GetBooksByThisAuthor(string authorNAme)
        {
            var bookByAtuthor = from book in _dbContext.Book
                                join author in _dbContext.BookAuthors
                                on book.AuthorID equals author.IID
                                where book.IsRemoved == false
                                && author.AuthorName == authorNAme
                                && book.AuthorID == author.IID
                                select new
                                {
                                    book.IID,
                                    book.ImageUrl,

                                };
            return bookByAtuthor.ToList().Take(4);

        }
        public object GetAllCategoryBook()
        {
            var FictionCategoryBook = from book in _dbContext.Book
                                      join author in _dbContext.BookAuthors
                                      on book.AuthorID equals author.IID
                                      where book.IsRecommended == true
                                      select new
                                      {
                                          author.IID,
                                          book.ImageUrl,
                                          author.AuthorName,
                                          book.BookTitle,
                                          book.Abstract

                                      };
            return FictionCategoryBook.ToList().Take(3);

        }
        //mahbub
        public List<Book> GetTopTenLatestBooks()
        {
            try
            {
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0, 0));
                var FictionCategoryBook = (from book in _dbContext.Book
                                           where book.PublishedDate >= oldestDate
                                           && book.PublishedDate <= DateTime.Now
                                           && book.IsLatest == true
                                           select book).Take(10).OrderBy(x => x.BookTitle).ToList();
                return FictionCategoryBook;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }
        public object GetAllFictionCategoryLatestBook()
        {
            try
            {
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0, 0));
                var FictionCategoryBook = from book in _dbContext.Book
                                          join author in _dbContext.BookAuthors
                                          on book.AuthorID equals author.IID
                                          where book.CategoryID == Convert.ToInt64(OB.Utilities.EnumCollection.ParentCategory.Fiction)
                                          && book.PublishedDate >= oldestDate
                                          && book.PublishedDate <= DateTime.Now
                                          && book.IsLatest == true

                                          select new
                                          {
                                              book.IID,
                                              book.ImageUrl,
                                              author.AuthorName,
                                              AuthorID=author.IID,
                                              book.BookTitle

                                          };
                return FictionCategoryBook.ToList().Take(4);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }


        }

        public object GetAllNonFictionCategoryLatestBook(Int64 IID)
        {
            try
            {
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0, 0));
                var FictionCategoryBook = from book in _dbContext.Book
                                          join author in _dbContext.BookAuthors
                                          on book.AuthorID equals author.IID
                                          where book.CategoryID == Convert.ToInt64(OB.Utilities.EnumCollection.ParentCategory.Non_Fiction)
                                         && book.PublishedDate >= oldestDate
                                          && book.PublishedDate <= DateTime.Now
                                          && book.IsLatest == true

                                          select new
                                          {
                                              book.IID,
                                              book.ImageUrl,
                                              author.AuthorName,
                                              AuthorID = author.IID,
                                              book.BookTitle

                                          };
                return FictionCategoryBook.ToList().Take(4);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }



        }

        public object GetAllNonFictionCategoryBook(Int64 IID)
        {
            try
            {
                var FictionCategoryBook = from book in _dbContext.Book
                                          join author in _dbContext.BookAuthors
                                          on book.AuthorID equals author.IID
                                          where book.CategoryID == Convert.ToInt64(OB.Utilities.EnumCollection.ParentCategory.Non_Fiction) && book.IsRecommended == true
                                          select new
                                          {
                                              book.IID,
                                              book.ImageUrl,
                                              author.AuthorName,
                                              AuthorID=author.IID,
                                              book.BookTitle

                                          };
                return FictionCategoryBook.ToList().Take(3);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }



        }
        public object GetFictionComingSoon()
        {
            try
            {
                DateTime newestDate = DateTime.Now.AddDays(90);

                var ComingSoonBook = from book in _dbContext.Book
                                     where book.IsRemoved == false
                                      && book.PublishedDate <= newestDate
                                       && book.PublishedDate >= DateTime.Now
                                         && book.CategoryID == Convert.ToInt64(OB.Utilities.EnumCollection.ParentCategory.Fiction)
                                     select new
                                     {
                                         book.IID,
                                         book.ImageUrl
                                     };
                return ComingSoonBook.ToList().Take(4);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }



        }
        public object GetNonFictionComingSoon()
        {
            try
            {
                DateTime newestDate = DateTime.Now.AddDays(90);

                var ComingSoonBook = from book in _dbContext.Book
                                     where book.IsRemoved == false
                                      && book.PublishedDate <= newestDate
                                       && book.PublishedDate >= DateTime.Now
                                       && book.CategoryID == Convert.ToInt64(OB.Utilities.EnumCollection.ParentCategory.Non_Fiction)
                                     select new
                                     {
                                         book.IID,
                                         book.ImageUrl
                                     };
                return ComingSoonBook.ToList().Take(4);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }



        }
        //mahbub
        public IEnumerable<Book> GetTopTenComingSoonBooks()
        {
            try
            {
                DateTime newestDate = DateTime.Now.AddDays(90);

                var ComingSoonBook = (from book in _dbContext.Book
                                      where book.IsRemoved == false
                                            && book.PublishedDate <= newestDate
                                            && book.PublishedDate >= DateTime.Now
                                      select book).Take(10).OrderBy(x => x.BookTitle).ToList();
                return ComingSoonBook;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }
        //mahbub
        public List<Book> GetTopTenFavouriteBooks()
        {
            try
            {
                var ComingSoonBook = (from book in _dbContext.Book.OrderByDescending(x => x.AvgRating)
                                      where book.IsRemoved == false
                                      select book).Take(10).OrderBy(x => x.BookTitle).ToList();
                return ComingSoonBook;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }

        public object GetAllPublishingThisMonth()
        {
            try
            {
                string currentMonth = DateTime.Now.Month.ToString();

                var books = from book in _dbContext.Book
                            join author in _dbContext.BookAuthors
                            on book.AuthorID equals author.IID
                            where book.IsRemoved == false
                            && book.PublishedDate.Month.ToString() == currentMonth
                            select new
                            {
                                author.IID,
                                author.Picture,
                                author.AuthorName,
                                author.WebsiteLink
                            };
                return books.ToList().Distinct();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }

        public int InsertBookAndBookFeatureChildXML(string bookAndBookFeatureChildXML)
        {
            using (DataHelper dHelper = new DataHelper())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertBookFeatureChildXML"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@BookXML", bookAndBookFeatureChildXML));

                            SqlParameter returnValue = new SqlParameter("@BookID", DbType.Int64);
                            returnValue.Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add(returnValue);
                            conn.Open();
                            cmd.Connection = conn;
                            int bookID = cmd.ExecuteNonQuery();
                            conn.Close();
                            return 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }
        public List<Book> GetTop4BooksAccordingtoAuthor(Int32 authorID)
        {
            try
            {
               // List<Book> top4Book=new List<Book>();
            var   top4Book = (from book in _dbContext.Book.OrderByDescending(book => book.AvgRating)
                                join author in _dbContext.BookAuthors on book.AuthorID equals author.IID
                                where book.AuthorID == authorID && book.IsRemoved == false

                                select  book).ToList();
                return top4Book;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }
        public List<BookMediaReview> GetAllMediaReviewsByBookId(long bookId)
        {
            try
            {
                var bookMediaReviews = _dbContext.BookMediaReviews.Where(x => x.IsRemoved == false && x.BookID == bookId).ToList();
                return bookMediaReviews;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public IQueryable<Book> GetAllBooksByAuthorId(long authId)
        {
            try
            {
                var bookListByAuth = _dbContext.Book.Where(x => x.IsRemoved == false && x.AuthorID == authId);
                return bookListByAuth;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Get data FictionCategoryByCategoryID by Asiful 07.06.2015
        /// </summary>
        /// 
        public object GetAllFictionCategoryBookByCategoryID(Int64 Iid)
        {
            var FictionCategoryBook = from book in _dbContext.Book
                                      join author in _dbContext.BookAuthors
                                      on book.AuthorID equals author.IID
                                      where book.CategoryID == Iid && book.IsRecommended == true
                                      select new
                                      {
                                          book.IID,
                                          book.ImageUrl,
                                          author.AuthorName,
                                          AuthorID = author.IID,
                                          book.BookTitle,
                                          book.Abstract

                                      };
            return FictionCategoryBook.ToList().Take(3);
        }

        public object GetAllFictionCategoryLatestBookByCategoryID(Int64 Iid)
        {
            try
            {
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0, 0));
                var FictionCategoryBook = from book in _dbContext.Book
                                          join author in _dbContext.BookAuthors
                                          on book.AuthorID equals author.IID
                                          where book.CategoryID == Iid
                                          && book.PublishedDate >= oldestDate
                                          && book.PublishedDate <= DateTime.Now
                                          && book.IsLatest == true

                                          select new
                                          {
                                              book.IID,
                                              book.ImageUrl,
                                              author.AuthorName,
                                              AuthorID = author.IID,
                                              book.BookTitle

                                          };
                return FictionCategoryBook.ToList().Take(4);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public object GetFictionComingSoonByID(Int64 Iid)
        {
            try
            {
                DateTime newestDate = DateTime.Now.AddDays(90);

                var ComingSoonBook = from book in _dbContext.Book
                                     where book.IsRemoved == false
                                      && book.PublishedDate <= newestDate
                                       && book.PublishedDate >= DateTime.Now
                                         && book.CategoryID == Iid
                                     select new
                                     {
                                         book.IID,
                                         book.ImageUrl
                                     };
                return ComingSoonBook.ToList().Take(4);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public IQueryable<BookOffer> GetAllBookFeatureByBookId(long bookId)
        {
            try
            {
                var bookFeatures = _dbContext.BookOffers.Where(x=> x.BookID == bookId);
                return bookFeatures;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}