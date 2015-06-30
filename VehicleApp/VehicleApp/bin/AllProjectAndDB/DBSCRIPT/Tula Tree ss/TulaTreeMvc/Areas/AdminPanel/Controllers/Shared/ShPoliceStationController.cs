using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.BLL.Basic;
using Tula.DAL;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers.Shared
{
    public class ShPoliceStationController : Controller
    {
        private DBConnectionString db = new DBConnectionString();
        private readonly PoliceStationRT _policeStationRt=new PoliceStationRT();
        // GET: AdminPanel/ShPoliceStation
        public ActionResult Index()
        {
            return null;
        }

        public JsonResult GetPoliceStationByDistrictId(long districtId)
        {
            try
            {
                var psList = _policeStationRt.GetAllPoliceStationsByDistrictId(districtId);
                return Json(new SelectList(psList, "IID", "Name"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
        }
    }
}