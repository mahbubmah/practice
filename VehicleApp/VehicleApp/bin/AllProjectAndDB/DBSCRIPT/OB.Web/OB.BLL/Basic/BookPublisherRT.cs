
using OB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Basic
{
    public class BookPublisherRT:IDisposable
    {
     private readonly OiiOBookDCDataContext _OiiOBookDCDataContext;
        public BookPublisherRT()
        {
            this._OiiOBookDCDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddBookPublisher(BookPublisher BookPublisher)
        {
            try
            {
                DatabaseHelper.Insert<BookPublisher>(BookPublisher);
            }
            catch (Exception ex) 
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateBookPublisher(BookPublisher BookPublisher)
        {
            try
            {
                BookPublisher BookPublisherNew = _OiiOBookDCDataContext.BookPublishers.SingleOrDefault(d => d.IID == BookPublisher.IID);

                DatabaseHelper.Update<BookPublisher>(_OiiOBookDCDataContext, BookPublisher, BookPublisherNew);

                //_OiiOBookDCDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

        public BookPublisher GetBookPublisherByIID(Int64 BookPublisherID)
        {
            try
            {
                BookPublisher BookPublisher = _OiiOBookDCDataContext.BookPublishers.SingleOrDefault(d => d.IID == BookPublisherID);
                //_OiiOBookDCDataContext.Dispose();
                return BookPublisher;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BookPublisher> GetBookPublisherName(string Name)
        {
            try
            {
                var BookPublishers = (from tr in _OiiOBookDCDataContext.BookPublishers.OrderBy(x => x.PublisherName)
                                 where tr.PublisherName.StartsWith(Name)
                                 select tr).ToList();
                return BookPublishers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BookPublisher> GetAllBookPublishers()
        {
            try
            {
                List<BookPublisher> BookPublishers = _OiiOBookDCDataContext.BookPublishers.OrderBy(x=>x.PublisherName).ToList();
                return BookPublishers;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }
        public List<PublisherNameLogo> GetAllLogo()
        {
            try
            {
                List<BookPublisher> BookPublishers = _OiiOBookDCDataContext.BookPublishers.OrderBy(x=>x.PublisherName).ToList();
                List<PublisherNameLogo> _obj=new List<PublisherNameLogo>();

               foreach(var publisher in BookPublishers){
                var pubObj = new PublisherNameLogo();
                pubObj.IID = publisher.IID;
                pubObj.PublisherName = publisher.PublisherName;
                pubObj.ImageUrl = publisher.PublisherLogoUrl;
                _obj.Add(pubObj);
               
               }
              

               return _obj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }
        public class PublisherNameLogo
        {
            public Int64 IID { get; set; }

            public string PublisherName { get; set; }
           // public string LoanTypeDescription { get; set; }

            public string ImageUrl { get; set; }
        }

        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members


           

            public List<BooKCategory> GetAllFictionCategory()
            {
                try{

                var FictionCategoryBook = (from tr in _OiiOBookDCDataContext.BooKCategory.OrderBy(x => x.CategoryName)
                                           where tr.ParentCategoryID==2
                                           select tr).ToList();
                return FictionCategoryBook;
                 }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }

            }
        /// <summary>
        /// Hasan add 2015.06.01
        /// </summary>
        /// <param name="queryStringOfFictionID"></param>
        /// <returns></returns>
            public List<BooKCategory> GetAllFictionCategory(int queryStringOfFictionID)
            {
                try
                {

                    var FictionCategoryBook = (from tr in _OiiOBookDCDataContext.BooKCategory.OrderBy(x => x.CategoryName)
                                               where tr.ParentCategoryID == queryStringOfFictionID
                                               select tr).ToList();
                    return FictionCategoryBook;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }

            }


        public IQueryable<Book> GetBooksPublishedByPublisher(long publisherId)
        {
            try
            {

                var bookList =
                    _OiiOBookDCDataContext.Book.Where(x => x.PublisherID == publisherId && x.IsRemoved == false);
                return bookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }

}
