using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class alertRT : IDisposable
    {
        private readonly OiiOHaatDCDataContext _OiiOHaatDBDataContext;
        public alertRT()
        {
            _OiiOHaatDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members




        public object GetAlertAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var Alert = from alert in dbContext.OiiOHaatAlerts
                            //where OtherContent.IsActive==true
                            select new { alert.IID, alert.Title, alert.Description, alert.Image, alert.IsActive };

                return Alert;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddAlertContent(OiiOHaatAlert Alertcontent)
        {
            try
            {
                DatabaseHelper.Insert<OiiOHaatAlert>(Alertcontent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOHaatAlert GetOtherContentByIID(long alertid)
        {
            try
            {
                // OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                OiiOHaatAlert alertContent = new OiiOHaatAlert();
                alertContent = _OiiOHaatDBDataContext.OiiOHaatAlerts.Single(d => d.IID == alertid);
                _OiiOHaatDBDataContext.Dispose();
                return alertContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateAlertcontent(OiiOHaatAlert alertcontent)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                OiiOHaatAlert alertContent = msDC.OiiOHaatAlerts.Single(d => d.IID == alertcontent.IID);
                DatabaseHelper.Update<OiiOHaatAlert>(msDC, alertcontent, alertContent);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public object GetAlert()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var Alert = from alert in dbContext.OiiOHaatAlerts
                            where alert.IsActive == true
                            select new { alert.IID, alert.Title, alert.Description, alert.Image, alert.IsActive };

                return Alert;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
