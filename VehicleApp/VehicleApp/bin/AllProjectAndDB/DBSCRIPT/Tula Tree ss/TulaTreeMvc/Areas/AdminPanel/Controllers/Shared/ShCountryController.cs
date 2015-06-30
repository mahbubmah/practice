using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.DAL;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers.Shared
{
    public class ShCountryController : Controller
    {
        private DBConnectionString db = new DBConnectionString();
        // GET: AdminPanel/ShCountry
        public ActionResult Index()
        {
            return null;
        }
    }
}