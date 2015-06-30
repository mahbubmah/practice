using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class AddGiverTracingRT : IDisposable
    {
        /// <summary>
        /// Created By : Asiful Islam
        /// </summary>
        public AddGiverTracingRT()
        { }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public void InsertAdGiverTracing(DAL.AdGiverTracing addGivrTrc)
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
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                AdGiverTracing userGrp = msDC.AdGiverTracings.Single(d => d.IID == adGiverTracing.IID);
                DatabaseHelper.Update<AdGiverTracing>(msDC, adGiverTracing, userGrp);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetAdGiverTracingAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var AdGiverTracing = from adgiverTracing in dbContext.AdGiverTracings
                                     join adgiver in dbContext.AdGivers on adgiverTracing.AdGiverID equals adgiver.IID
                                     select new { adgiverTracing.IID, adgiverTracing.AdGiverID,name=adgiver.Name, adgiverTracing.MaterialID, 
                                         adgiverTracing.IPAddress, adgiverTracing.MACAddress, adgiverTracing.BrowserNameID, 
                                         adgiverTracing.BrowsingTimeDuration,adgiverTracing.IsRemoved };

                return AdGiverTracing;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public AdGiverTracing GetAddGiverTracingIID(int AddGiverTracingID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                AdGiverTracing adGivertracing = new AdGiverTracing();
                adGivertracing = dbContext.AdGiverTracings.Single(d => d.IID == AddGiverTracingID);
                dbContext.Dispose();
                return adGivertracing;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<AdGiverTracing> GetAdGiverTracingByIID(Int64 RegisteredUser)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                //AdGiverTracing Registereduser = new AdGiverTracing();
                List<AdGiverTracing> Registereduser = new List<AdGiverTracing>();
                Registereduser = dbContext.AdGiverTracings.Where(d => d.AdGiverID ==RegisteredUser).ToList();
                dbContext.Dispose();
                return Registereduser;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<AdGiverTracing> GetAdGiverTracingpID(int AdGiverTracingIID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<AdGiverTracing> AdGiverTracingList = new List<AdGiverTracing>();
                AdGiverTracingList = dbContext.AdGiverTracings.Where(d => d.AdGiverID == AdGiverTracingIID).ToList();

                dbContext.Dispose();
                return AdGiverTracingList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetAdGiverTracingListViewByIID(long registeredUser)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var AdGivertracing = from adgiverTracing in dbContext.AdGiverTracings
                                     join adgiver in dbContext.AdGivers on adgiverTracing.AdGiverID equals adgiver.IID
                                     join material in dbContext.Materials on adgiverTracing.MaterialID equals material.IID
                                     select new { adgiverTracing.IID, Email=adgiver.EmailID,adgiverTracing.AdGiverID, adgiverTracing.MaterialID,MaterialCode=material.Code, adgiverTracing.IPAddress, adgiverTracing.MACAddress, adgiverTracing.BrowserNameID, adgiverTracing.BrowsingTimeDuration };
                var addgivrtracing = AdGivertracing.Where(d => d.AdGiverID == registeredUser).ToList();
                return addgivrtracing;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        //public AdGiverTracing GetAdgiverEmailName(long nameID)
        //{
        //    try
        //    {
        //        OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
        //        AdGiverTracing AdGiverTracingEmail = new AdGiverTracing();
        //         AdGiverTracingEmail = from adgiverTracing in dbContext.AdGiverTracings
        //                             join adgiver in dbContext.AdGivers on adgiverTracing.AdGiverID equals adgiver.IID
        //                             //join material in dbContext.Materials on adgiverTracing.MaterialID equals material.IID
        //                             select new { adgiverTracing.IID, Email = adgiver.EmailID, Name=adgiver.Name,adgiverTracing.AdGiverID };
        //         //var addgivrtracingName = AdGiverTracingEmail.Where(d => d.AdGiverID == nameID).ToList();


        //        dbContext.Dispose();
        //        return AdGiverTracingEmail;
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}
    }
}
