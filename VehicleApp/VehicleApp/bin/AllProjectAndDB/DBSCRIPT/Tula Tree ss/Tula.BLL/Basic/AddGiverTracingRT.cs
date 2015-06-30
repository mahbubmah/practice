using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class AddGiverTracingRt : IDisposable
    {
        private readonly DBConnectionString _db;

        public AddGiverTracingRt()
        {
             _db = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public void InsertAdGiverTracing(AdGiverTracing addGivrTrc)
        {
            try
            {
                DatabaseHelper.Insert<AdGiverTracing>(addGivrTrc);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateadGiverTracing(AdGiverTracing adGiverTracing)
        {
            try
            {   
                
             
                var userGrp = _db.AdGiverTracings.Single(d => d.IID == adGiverTracing.IID);
                DatabaseHelper.Update<AdGiverTracing>(_db, adGiverTracing, userGrp);
                _db.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetAdGiverTracingAllForListView()
        {
            try
            {
                

                var adGiverTracing = from adgiverTracing in _db.AdGiverTracings
                                     join adgiver in _db.AdGivers on adgiverTracing.AdGiverID equals adgiver.IID
                                     select new { adgiverTracing.IID, adgiverTracing.AdGiverID,name=adgiver.Name, adgiverTracing.MaterialID, 
                                         adgiverTracing.IPAddress, adgiverTracing.MACAddress, adgiverTracing.BrowserNameID, 
                                         adgiverTracing.BrowsingTimeDuration,adgiverTracing.IsRemoved };

                return adGiverTracing;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public AdGiverTracing GetAddGiverTracingIid(int addGiverTracingId)
        {
            try
            {
               var adGivertracing = _db.AdGiverTracings.Single(d => d.IID == addGiverTracingId);
                return adGivertracing;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<AdGiverTracing> GetAdGiverTracingByIid(Int64 registeredUser)
        {
            try
            {
  
            var registereduser = _db.AdGiverTracings.Where(d => d.AdGiverID ==registeredUser).ToList();
                return registereduser;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<AdGiverTracing> GetAdGiverTracingpId(int adGiverTracingIid)
        {
            try
            {
          
                var adGiverTracingList = _db.AdGiverTracings.Where(d => d.AdGiverID == adGiverTracingIid).ToList();
                return adGiverTracingList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetAdGiverTracingListViewByIid(long registeredUser)
        {
            try
            {
              

                var adGivertracing = from adgiverTracing in _db.AdGiverTracings
                                     join adgiver in _db.AdGivers on adgiverTracing.AdGiverID equals adgiver.IID
                                     join material in _db.Materials on adgiverTracing.MaterialID equals material.IID
                                     select new { adgiverTracing.IID, Email=adgiver.EmailID,adgiverTracing.AdGiverID, adgiverTracing.MaterialID,MaterialCode=material.Code, adgiverTracing.IPAddress, adgiverTracing.MACAddress, adgiverTracing.BrowserNameID, adgiverTracing.BrowsingTimeDuration };
                var addgivrtracing = adGivertracing.Where(d => d.AdGiverID == registeredUser).ToList();
                return addgivrtracing;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
