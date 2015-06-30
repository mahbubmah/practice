using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Basic
{
    public class NewsLetterRT:IDisposable
    {
        private readonly OiiOMartDBDataContext _dbContex;
        
        public NewsLetterRT()
        {
            this._dbContex = DatabaseHelper.GetDataModelDataContext();
        }

        public object GetNewsLetterSubscribeAllForListView()
        {
            try
            {
                OiiOMartDBDataContext dbContex = DatabaseHelper.GetDataModelDataContext();

                var letterList = from letter in dbContex.NewsLetterSubscribes
                                 select new { letter.IID, letter.UserEmail, letter.SubscribeDate, letter.IsSubscribe };
                return letterList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public void AddNewsLetterSubscribe(NewsLetterSubscribe letter)
        {
            try
            {
                DatabaseHelper.Insert<NewsLetterSubscribe>(letter);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<NewsLetterSubscribe> GetLetterListByEmail(string email)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<NewsLetterSubscribe> letterList = dbContext.NewsLetterSubscribes.Where(con => con.UserEmail == email).ToList();
                return letterList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public NewsLetterSubscribe GetNewsLetterSubscribeByIID(int letterID)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                NewsLetterSubscribe letter = new NewsLetterSubscribe();
                letter = dbContext.NewsLetterSubscribes.Single(d => d.IID == letterID);
                dbContext.Dispose();
                return letter;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateNewsLetterSubscribe(NewsLetterSubscribe letter)
        {
            try
            {
                OiiOMartDBDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                NewsLetterSubscribe con = msDC.NewsLetterSubscribes.Single(d => d.IID == letter.IID);
                DatabaseHelper.Update<NewsLetterSubscribe>(msDC, letter, con);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<NewsLetterSubscribe> GetEmailSubscriber(string EmailSubscriber)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<NewsLetterSubscribe> EmailSubscriberList = new List<NewsLetterSubscribe>();
                EmailSubscriberList = dbContext.NewsLetterSubscribes.Where(d => d.IID != null && d.IsSubscribe == true && d.UserEmail.Contains(EmailSubscriber)).ToList();
                dbContext.Dispose();
                return EmailSubscriberList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public NewsLetterSubscribe GetEmailSubscribrIDByEmail(string EmailSubscribr)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                NewsLetterSubscribe Emailsubscribr = new NewsLetterSubscribe();
                Emailsubscribr = dbContext.NewsLetterSubscribes.Single(d => d.UserEmail == EmailSubscribr && d.IsSubscribe == true);

                dbContext.Dispose();
                return Emailsubscribr;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
