using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.DAL;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers.Shared
{
    public class ShLocationController : Controller
    {
        private DBConnectionString db = new DBConnectionString();
        // GET: AdminPanel/ShLocation
        public ActionResult Index()
        {
            return View();
        }
    }
}