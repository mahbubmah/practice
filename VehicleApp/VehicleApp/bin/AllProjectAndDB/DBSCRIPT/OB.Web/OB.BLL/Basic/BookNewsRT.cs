using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;

namespace OB.BLL.Basic
{
   public class BookNewsRT: IDisposable
    {

        private readonly OiiOBookDCDataContext _OiiOBookDCDataContext;
        public BookNewsRT()
        {
            this._OiiOBookDCDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public void AddNewsContent(BookNews newsontent)
        {
            try
            {
                DatabaseHelper.Insert<BookNews>(newsontent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetNEWSContentAllForListView()
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var NewsList = from News in dbContext.BookNews

                               orderby News.IID descending
                               select new { News.IID, News.Audio, News.ImageUrl, News.NewsDescription, News.VideoLink, News.PublishDate,News.HeadLine,News.IsRemoved }; //divisionOrState.Name
                
                return NewsList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public BookNews GetOtherContentByIID(long BooknewsID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                BookNews booNews = new BookNews();
                booNews = dbContext.BookNews.Single(d => d.IID == BooknewsID);

                dbContext.Dispose();
                return booNews;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCMScontent(BookNews booknewsupdate)
        {
            try
            {
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                BookNews objbooknwes = msDC.BookNews.Single(d => d.IID == booknewsupdate.IID);
                DatabaseHelper.Update<BookNews>(msDC, booknewsupdate, objbooknwes);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<BookNews> GetNEWSContentAll()
        {
            try
            {
                List<BookNews> bookNewColl = _OiiOBookDCDataContext.BookNews.Where(x=>x.IsRemoved==false).OrderByDescending(x => x.IID ).ToList();
                return bookNewColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public BookNews getbooKnewsbyIID(int BookNewsID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                BookNews pic = new BookNews();
                pic = dbContext.BookNews.Single(d => d.IID == BookNewsID);
                dbContext.Dispose();
                return pic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BookNews> GetActiveLeatestVideoForShow()
        {
   
            try
            {
                var Content = _OiiOBookDCDataContext.BookNews.Where(d => d.IsRemoved == false).ToList();
             _OiiOBookDCDataContext.Dispose();
                return Content;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        
    }
}
