using System;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class AlertRt : IDisposable
    {
        private readonly DBConnectionString _db;
        public AlertRt()
        {
            _db = DatabaseHelper.GetDataModelDataContext();
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
                var alert = from treeAlert in _db.TulaTreeAlerts
                            select new { treeAlert.IID, treeAlert.Title, treeAlert.Description, treeAlert.Image, treeAlert.IsActive };

                return alert;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddAlertContent(TulaTreeAlert alertcontent)
        {
            try
            {
                DatabaseHelper.Insert<TulaTreeAlert>(alertcontent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public TulaTreeAlert GetOtherContentByIid(long alertid)
        {
            try
            {
                var alertContent = new TulaTreeAlert();
                alertContent = _db.TulaTreeAlerts.Single(d => d.IID == alertid);
                _db.Dispose();
                return alertContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateAlertcontent(TulaTreeAlert alertcontent)
        {
            try
            {
             

                var alertContent = _db.TulaTreeAlerts.Single(d => d.IID == alertcontent.IID);
                DatabaseHelper.Update<TulaTreeAlert>(_db, alertcontent, alertContent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public object GetAlert()
        {
            try
            {
                var alert = from treeAlert in _db.TulaTreeAlerts
                            where treeAlert.IsActive 
                            select new { treeAlert.IID, treeAlert.Title, treeAlert.Description, treeAlert.Image, treeAlert.IsActive };

                return alert;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
