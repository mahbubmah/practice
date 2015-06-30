using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.Utilities;

namespace TulaTreeMvc.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
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
                return View();
            }
            catch (Exception ex)
            {

                return View("Error", ErrorHelper.GetInstanceAndWriteToLogFile(ex.Message, ex.StackTrace, _pageLogPath));
            }
         
        }
    }
}