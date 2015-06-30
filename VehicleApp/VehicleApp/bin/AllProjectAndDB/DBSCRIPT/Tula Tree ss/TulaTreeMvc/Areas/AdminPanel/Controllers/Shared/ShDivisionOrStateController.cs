using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.BLL.Basic;
using Tula.DAL;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers.Shared
{
    public class ShDivisionOrStateController : Controller
    {

        private DBConnectionString db = new DBConnectionString();
        private readonly DivisionOrStateRT _divisionOrStateRt=new DivisionOrStateRT();
        

        // GET: AdminPanel/ShDivisionOrState
        public ActionResult Index()
        {
            return null;
        }

        public JsonResult GetDivOrStatesByCountryId(int countryId)
        {
            var divOrStateList = _divisionOrStateRt.GetDistrictOrStateForCountryId(countryId);
            return Json(new SelectList(divOrStateList, "IID", "Name"), JsonRequestBehavior.AllowGet);
        }
    }
}