using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.BLL.Basic;
using Tula.DAL;
using Tula.Utilities;
using TulaTreeMvc.Models;

namespace TulaTreeMvc.Controllers
{
    public class DefaultController : Controller
    {

        public DefaultController()
        {
            ViewBag.CMSContent = new CmsRt().GetCmsContentAllForListView();
        }

        // GET: Default
        public ActionResult Index()
        {
            string _visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string _actionName = actionName + controllerName.First().ToString().ToUpper() + controllerName.Substring(1);
            string _pageLogPath = Server.MapPath("~/Log file/" + _actionName + ".txt");
            LogFileHelper.VisitorLogFileWritten(_visitorLogPath);

            try
            {
                var model = new DefaultViewModel();
                using (var customClientRt = new CustomClientRT())
                {
                    model.OtherContents = customClientRt.GetOtherContent().Take(3).ToList();
                    model.SpotLightAds = customClientRt.GetAllSpotLightAds().Take(3).ToList();
                    model.LatestRandomAds = customClientRt.GetAllLatestRandomAds().Take(12).ToList();
                    model.LatestAdsInForSell = customClientRt.GetAllLatestRandomAdsForSale().Take(20).ToList();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ErrorHelper.GetInstanceAndWriteToLogFile(ex.Message, ex.StackTrace, _pageLogPath));
            }

        }

        public ActionResult Error()
        {
            return View();
        }
    }
}