using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;


namespace OH.BLL.Basic
{
    public class EmailSubscriptionRT : IDisposable
    {
         /// <summary>
        /// Created By : Asiful Islam
        /// </summary>
        public EmailSubscriptionRT()
        { }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members




        public List<OiiONewsLetter> GetEmailSubscriber(string EmailSubscriber)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<OiiONewsLetter> EmailSubscriberList = new List<OiiONewsLetter>();
                EmailSubscriberList = dbContext.OiiONewsLetters.Where(d => d.IID != null && d.IsSubscribe==true && d.UserEmail.Contains(EmailSubscriber)).ToList();
                dbContext.Dispose();
                return EmailSubscriberList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddEmailSubscriber(OiiONewsLetter EmailSubscribe)
        {
            try
            {
                DatabaseHelper.Insert<OiiONewsLetter>(EmailSubscribe);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateEmailSubscribe(OiiONewsLetter EmailSubscribe)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                OiiONewsLetter Emailsubscribe = msDC.OiiONewsLetters.Single(d => d.UserEmail == EmailSubscribe.UserEmail);
                DatabaseHelper.Update<OiiONewsLetter>(msDC, EmailSubscribe, Emailsubscribe);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        //public OiiONewsLetter GetEmailSubscribrByEmail(string p)
        //{
        //    throw new NotImplementedException();
        //}

        public OiiONewsLetter GetEmailSubscribrIDByEmail(string EmailSubscribr)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                OiiONewsLetter Emailsubscribr = new OiiONewsLetter();
                Emailsubscribr = dbContext.OiiONewsLetters.Single(d => d.UserEmail == EmailSubscribr && d.IsSubscribe == true);

                dbContext.Dispose();
                return Emailsubscribr;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
