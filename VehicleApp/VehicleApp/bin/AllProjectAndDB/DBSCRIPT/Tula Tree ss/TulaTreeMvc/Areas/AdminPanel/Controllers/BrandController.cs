using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Tula.BLL.Basic;
using Tula.DAL;
using TulaTreeMvc.Areas.AdminPanel.Models;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers
{
    public class BrandController : Controller
    {
       private DBConnectionString db = new DBConnectionString();

        // GET: /AdminPanel/Brand/
        public ActionResult Index(int? page)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            var brandList = db.Brands.OrderBy(x => x.Name).ToList();
            return View(brandList.ToPagedList(pageNumber,pageSize));
        }

        // GET: /AdminPanel/Brand/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: /AdminPanel/Brand/Create
        public ActionResult Create()
        {
            var countries = db.Countries.Where(x => x.IsRemoved == false).OrderBy(x => x.Name);
            ViewBag.CountrySelectList = new SelectList(countries, "IID", "Name");
            return View();
        }

        // POST: /AdminPanel/Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandViewModel model)
        {
            var isBrandAlreadyExists = db.Brands.Count(b => b.Name == model.Name) > 0;
            if (isBrandAlreadyExists)
            {
                ModelState.AddModelError("Name", "Brand " + model.Name + " alredy exist.");
            }
            var brand = new Brand()
            {
                Name = model.Name,
                Origin = model.Origin,
                EastblishYear= model.EastblishYear,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                IsRemoved = false,


            };
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /AdminPanel/Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            var countries = db.Countries.Where(x => x.IsRemoved == false).OrderBy(x => x.Name).ToList();
            ViewBag.CountrySelectList = new SelectList(countries, "IID", "Name",brand.Origin);

           
            var model = new BrandViewModel() {Name = brand.Name,Origin = brand.Origin,EastblishYear = brand.EastblishYear,IsRemoved = brand.IsRemoved};
            return View(model);
        }

        // POST: /AdminPanel/Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandViewModel model,int id)
        {
            var isBrandAlreadyExists = db.Brands.Count(b => b.Name == model.Name &&b.IID!=id) > 0;
            if (isBrandAlreadyExists)
            {
                ModelState.AddModelError("Name", "Brand " + model.Name + " alredy exist.");
            }
            if (ModelState.IsValid)
            {
                var objBrand = db.Brands.Single(b => b.IID == id) ?? new Brand();

                objBrand.Name = model.Name;
                objBrand.Origin = model.Origin;
                objBrand.EastblishYear = model.EastblishYear;
                objBrand.IsRemoved = model.IsRemoved;

                objBrand.ModifiedBy = 1;
                objBrand.ModifiedDate = DateTime.Now;

                db.Entry(objBrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

      
        // POST: /AdminPanel/Brand/Delete/5
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexDelete(int? iid)
        {
            Brand brand = db.Brands.Find(iid);
            brand.IsRemoved = true;
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
