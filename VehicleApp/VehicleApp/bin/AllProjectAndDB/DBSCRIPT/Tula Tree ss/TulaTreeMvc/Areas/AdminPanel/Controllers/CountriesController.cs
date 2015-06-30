using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Tula.DAL;
using TulaTreeMvc.Areas.AdminPanel.Models;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers
{
    public class CountriesController : Controller
    {
        private DBConnectionString db = new DBConnectionString();

        // GET: AdminPanel/Countries
        public ActionResult Index(int? page)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            var countryList = db.Countries.OrderBy(x=>x.Name).ToList();
            return View(countryList.ToPagedList(pageNumber, pageSize));
        }

       
        // GET: AdminPanel/Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: AdminPanel/Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryViewModel model)
        {
            var isCountryAlredyNameExist = db.Countries.Count(c => c.Name == model.Name) > 0;

            if (isCountryAlredyNameExist)
            {
                ModelState.AddModelError("Name", "Country "+model.Name+" alredy exist.");
            }

            var country = new Country()
            {
                Name = model.Name,
                Code = model.Code,
                ISDCode = model.ISDCode,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                IsRemoved = false,
            };

            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: AdminPanel/Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = db.Countries.Find(id);
         
            if (country == null)
            {
                return HttpNotFound();
            }
            var model = new CountryViewModel() { Name = country.Name, ISDCode = country.ISDCode, Code = country.Code ,IsRemoved = country.IsRemoved};
            return View(model);
        }

        // POST: AdminPanel/Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryViewModel model,int id)
        {
            var isCountryAlredyNameExist = db.Countries.Count(c => c.Name == model.Name && c.IID != id) > 0;

            if (isCountryAlredyNameExist)
            {
                ModelState.AddModelError("Name", "Country alredy exist.");
            }
            var objCountry = db.Countries.Single(c => c.IID == id);
            if (objCountry==null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                

                objCountry.Name = model.Name;
                objCountry.Code = model.Code;
                objCountry.IsRemoved = model.IsRemoved;
                objCountry.ISDCode = model.ISDCode;

                objCountry.ModifiedBy = 1;
                objCountry.ModifiedDate = DateTime.Now;

                db.Entry(objCountry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexDelete(int? iid)
        {
            Country country = db.Countries.Find(iid);
            country.IsRemoved = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
