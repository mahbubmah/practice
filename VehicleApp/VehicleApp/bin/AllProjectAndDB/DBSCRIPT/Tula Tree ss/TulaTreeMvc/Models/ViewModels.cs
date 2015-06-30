using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.DAL;
using Tula.Utilities;

namespace TulaTreeMvc.Models
{
    public class ViewModels
    {
       
    }

   

    public class DefaultViewModel
    {
        public List<OH_OT_GetAllOtherContent_Result> OtherContents { get; set; }
        public List<OH_SP_GetAllSpotLightAds_Result> SpotLightAds { get; set; }
        public List<SP_GetRandomAllRecentMaterialAds_Result> LatestRandomAds { get; set; }
        public List<SP_GetRandomAllRecentMaterialAccordingToCategoreyIID_Result> LatestAdsInForSell { get; set; }
    }
}