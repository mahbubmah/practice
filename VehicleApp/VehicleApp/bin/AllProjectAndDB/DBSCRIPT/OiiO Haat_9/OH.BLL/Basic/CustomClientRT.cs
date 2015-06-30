using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class CustomClientRT : IDisposable
    {

        private readonly OiiOHaatDCDataContext _dbContext;
        
        public CustomClientRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public List<OH_SP_GetAllSpotLightAdsResult> GetAllSpotLightAds()
        {
            var getAllSpotLightAds = _dbContext.OH_SP_GetAllSpotLightAds().ToList();
            return getAllSpotLightAds;
        }

        public SP_GetMaterialAccordingToMaterialIIDResult GetAdDetailsAccordingToId(Int64 IiD)
        {
            var obj = _dbContext.SP_GetMaterialAccordingToMaterialIID(IiD).SingleOrDefault();
            return obj;
        }

        public List<SP_GetAllLatestAdsResult> GetAllLatestAds()
        {
            var obj = _dbContext.SP_GetAllLatestAds().ToList();
            return obj;
        }
      /// <summary>
      /// Hasan Add For RandomLatestAds
      /// </summary>
      /// <returns></returns>
        public List<SP_GetRandomAllRecentMaterialAdsResult> GetAllLatestRandomAds()
        {
            var obj = _dbContext.SP_GetRandomAllRecentMaterialAds().ToList();
            return obj;
        }
        /// <summary>
        /// Hasan Add For RandomRecentForSaleAds 
        /// </summary>
        /// <returns></returns>
        public List<SP_GetRandomAllRecentMaterialAccordingToCategoreyIIDResult> GetAllLatestRandomAdsForSale()
        {
            var obj = _dbContext.SP_GetRandomAllRecentMaterialAccordingToCategoreyIID().ToList();
            return obj;
        }



        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public List<OH_OT_GetAllOtherContentResult> GetOtherContent()
        {
            var getAllOtherContent = _dbContext.OH_OT_GetAllOtherContent().ToList();
            return getAllOtherContent;
        }
    }
}
