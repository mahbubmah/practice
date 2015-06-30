using OB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Basic
{
    public class BookAuthorRT:IDisposable
    {
     private readonly OiiOBookDCDataContext _OiiOBookDCDataContext;
        public BookAuthorRT()
        {
            this._OiiOBookDCDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddBookAuthor(BookAuthor BookAuthor)
        {
            try
            {
                DatabaseHelper.Insert<BookAuthor>(BookAuthor);
            }
            catch (Exception ex) 
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateBookAuthor(BookAuthor BookAuthor)
        {
            try
            {
                BookAuthor BookAuthorNew = _OiiOBookDCDataContext.BookAuthors.SingleOrDefault(d => d.IID == BookAuthor.IID);

                DatabaseHelper.Update<BookAuthor>(_OiiOBookDCDataContext, BookAuthor, BookAuthorNew);

                //_OiiOBookDCDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

        public BookAuthor GetBookAuthorByIID(Int64 BookAuthorID)
        {
            try
            {
                BookAuthor BookAuthor = _OiiOBookDCDataContext.BookAuthors.SingleOrDefault(d => d.IID == BookAuthorID);
                //_OiiOBookDCDataContext.Dispose();
                return BookAuthor;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BookAuthor> GetBookAuthorName(string Name)
        {
            try
            {
                var BookAuthors = (from tr in _OiiOBookDCDataContext.BookAuthors.OrderBy(x => x.AuthorName)
                                   where tr.AuthorName.StartsWith(Name)
                                 select tr).ToList();
                return BookAuthors;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BookAuthor> GetAllBookAuthors()
        {
            try
            {
                List<BookAuthor> _BookAuthors = _OiiOBookDCDataContext.BookAuthors.OrderBy(x => x.AuthorName).ToList();
                return _BookAuthors;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

        public object GetOneFeaturedAuthor()
        {
            var FeaturedAuthor = from author in _OiiOBookDCDataContext.BookAuthors
                                      //join author in _OiiOBookDCDataContext.BookAuthors
                                      //on book.AuthorID equals author.IID
                                      where author.IsFeatured == true && author.IsRemoved == false
                                      select new
                                      {
                                          author.IID,
                                          author.Picture,
                                          author.AuthorName,
                                          author.FavouriteQuote,
                                          author.WebsiteLink

                                      };
            return FeaturedAuthor.ToList().Take(1);

        }


        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members


            public object GetSearchedAuthor()
            {
                throw new NotImplementedException();
            }

            public List<AuthorAlphabet> GetSearchedAuthorsAlphabeticalLists()
            {
                try
                {
                    var lst = new List<AuthorAlphabet>();
                    for (int i = 65; i <= 90; i++)
                    {
                        var obj = new AuthorAlphabet();

                        obj.IID = i;
                        obj.Alphabet = ((char)i).ToString();

                        lst.Add(obj);
                    }
                        return lst;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            public class AuthorAlphabet
            {
                public Int32 IID { get; set; }
               
                public string Alphabet { get; set; }
              
            }

            public object GetAllSearchedAuthor(string alphabet)
            {
                var SearchedAuthor = from author in _OiiOBookDCDataContext.BookAuthors
                                     where author.IsFeatured == true 
                                     && author.IsRemoved == false
                                     && author.AuthorName.Contains(alphabet)
                                     select new
                                     {
                                         author.IID,
                                         author.Picture,
                                         author.AuthorName,
                                         author.AboutAuthor,
                                         author.WebsiteLink

                                     };
                return SearchedAuthor.ToList();
            }



/// <summary>
/// Asiful 07.06.2015
/// </summary>
/// <param name="Iid"></param>
/// <returns></returns>
            public object GetOneFeaturedAuthorBycategory(Int64 Iid)
            {
                var FeaturedAuthor = from author in _OiiOBookDCDataContext.BookAuthors
                                     join book in _OiiOBookDCDataContext.Book
                                     on author.IID equals book.AuthorID
                                     where author.IsFeatured == true && author.IsRemoved == false && book.CategoryID==Iid
                                     select new
                                     {
                                         author.IID,
                                         author.Picture,
                                         author.AuthorName,
                                         author.FavouriteQuote,
                                         author.WebsiteLink

                                     };
                return FeaturedAuthor.ToList().Take(1);
            }

            public object GetAllBookAuthorsForShow()
            {
                var FeaturedAuthor = from author in _OiiOBookDCDataContext.BookAuthors
                                     join country in _OiiOBookDCDataContext.Countries
                                     on author.CountryID equals country.IID
                                     where author.IsFeatured == true && author.IsRemoved == false 
                                     select new
                                     {
                                         author.IID,
                                         author.Picture,
                                         author.AuthorName,
                                         author.FavouriteQuote,
                                         author.AboutAuthor,
                                         country.Name,
                                         author.IsFeatured,
                                         author.IsRemoved

                                     };
                return FeaturedAuthor.ToList();
            }
    }
}
