using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.BLL.Basic;
using Tula.DAL;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers.Shared
{
    public class ShDistrictController : Controller
    {
        private DBConnectionString db = new DBConnectionString();
        private readonly DistrictRT _districtRt=new DistrictRT();
        // GET: AdminPanel/ShDistrict
        public ActionResult Index()
        {
            return null;
        }

        public JsonResult GetDistrictByCountryIdAndDivOrStateId(int countryId, long divOrStateId)
        {
            try
            {
                var districtList = _districtRt.GetDistrictByCountryIdAndDivisionOrStateId(countryId, divOrStateId);
                return Json(new SelectList(districtList, "IID", "Name"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
       
        }
    }
}