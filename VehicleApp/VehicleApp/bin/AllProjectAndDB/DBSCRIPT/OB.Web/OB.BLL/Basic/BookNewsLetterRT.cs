using OB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OB.BLL.Basic
{
    
     public class BookNewsLetterRT:IDisposable
    {
        private readonly OiiOBookDCDataContext _dbContex;
        
        public BookNewsLetterRT()
        {
            this._dbContex = DatabaseHelper.GetDataModelDataContext();
        }

        public object GetBookNewsLetterAllForListView()
        {
            try
            {
                OiiOBookDCDataContext dbContex = DatabaseHelper.GetDataModelDataContext();

                var letterList = from letter in dbContex.BookNewsLetters
                                 select new { letter.IID, letter.UserEmail, letter.SubscribeDate, letter.IsSubscribe };
                return letterList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public void AddBookLetter(BookNewsLetter letter)
        {
            try
            {
                DatabaseHelper.Insert<BookNewsLetter>(letter);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<BookNewsLetter> GetLetterListByEmail(string email)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<BookNewsLetter> letterList = dbContext.BookNewsLetters.Where(con => con.UserEmail == email).ToList();
                return letterList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public BookNewsLetter GetHaatLetterByIID(int letterID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                BookNewsLetter letter = new BookNewsLetter();
                letter = dbContext.BookNewsLetters.Single(d => d.IID == letterID);
                dbContext.Dispose();
                return letter;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateHaatLetter(BookNewsLetter letter)
        {
            try
            {
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                BookNewsLetter con = msDC.BookNewsLetters.Single(d => d.IID == letter.IID);
                DatabaseHelper.Update<BookNewsLetter>(msDC, letter, con);
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

        public List<BookNewsLetter> GetEmailSubscriber(string EmailSubscriber)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<BookNewsLetter> EmailSubscriberList = new List<BookNewsLetter>();
                EmailSubscriberList = dbContext.BookNewsLetters.Where(d => d.IID != null && d.IsSubscribe == true && d.UserEmail.Contains(EmailSubscriber)).ToList();
                dbContext.Dispose();
                return EmailSubscriberList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public BookNewsLetter GetEmailSubscribrIDByEmail(string EmailSubscribr)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                BookNewsLetter Emailsubscribr = new BookNewsLetter();
                Emailsubscribr = dbContext.BookNewsLetters.Single(d => d.UserEmail == EmailSubscribr && d.IsSubscribe == true);

                dbContext.Dispose();
                return Emailsubscribr;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}


