using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class CustomClientRT : IDisposable
    {

        private readonly DBConnectionString _db;
        
        public CustomClientRT()
        {
            this._db = DatabaseHelper.GetDataModelDataContext();
        }

        public List<OH_SP_GetAllSpotLightAds_Result> GetAllSpotLightAds()
        {
            var getAllSpotLightAds = _db.OH_SP_GetAllSpotLightAds().ToList();
            return getAllSpotLightAds;
        }

        public SP_GetMaterialAccordingToMaterialIID_Result GetAdDetailsAccordingToId(Int64 IiD)
        {
            var obj = _db.SP_GetMaterialAccordingToMaterialIID(IiD).SingleOrDefault();
            return obj;
        }

        public List<SP_GetAllLatestAds_Result> GetAllLatestAds()
        {
            var obj = _db.SP_GetAllLatestAds().ToList();
            return obj;
        }
      /// <summary>
      /// Hasan Add For RandomLatestAds
      /// </summary>
      /// <returns></returns>
        public List<SP_GetRandomAllRecentMaterialAds_Result> GetAllLatestRandomAds()
        {
            var obj = _db.SP_GetRandomAllRecentMaterialAds().ToList();
            return obj;
        }
        /// <summary>
        /// Hasan Add For RandomRecentForSaleAds 
        /// </summary>
        /// <returns></returns>
        public List<SP_GetRandomAllRecentMaterialAccordingToCategoreyIID_Result> GetAllLatestRandomAdsForSale()
        {
            var obj = _db.SP_GetRandomAllRecentMaterialAccordingToCategoreyIID().ToList();
            return obj;
        }



        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public List<OH_OT_GetAllOtherContent_Result> GetOtherContent()
        {
            var getAllOtherContent = _db.OH_OT_GetAllOtherContent().ToList();
            return getAllOtherContent;
        }
    }
}
