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
    public class ColorController : Controller
    {
        private DBConnectionString db = new DBConnectionString();

        // GET: /AdminPanel/Color/
        public ActionResult Index(int? page)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            var colorList = db.Colors.OrderBy(x => x.Name).ToList();
            return View(colorList.ToPagedList(pageNumber, pageSize));
        }

        // GET: /AdminPanel/Color/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // GET: /AdminPanel/Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AdminPanel/Color/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColorViewModel model)
        {
            var isColorAlreadyExists = db.Colors.Count(c => (c.Name == model.Name || c.Code == model.Code)) > 0;
            if (isColorAlreadyExists)
            {
               ModelState.AddModelError("Name", "Color name or code alredy exist.");
             
            }
            var color = new Color();
            {
                color.Name = model.Name;
                color.Code = model.Code;
                color.CreatedBy = 1;
                color.CreatedDate = DateTime.Now;
                color.IsRemoved = false;
            };
             if (ModelState.IsValid)
            {
                db.Colors.Add(color);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /AdminPanel/Color/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            var model = new ColorViewModel() {Name = color.Name, Code = color.Code, IsRemoved = color.IsRemoved};
            return View(model);
        }

        // POST: /AdminPanel/Color/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ColorViewModel model,int id)
        {
            var isColorAlreadyExists = db.Colors.Count(c => (c.Name == model.Name || c.Code==model.Code) && c.IID != id) > 0;
            if (isColorAlreadyExists)
            {
                ModelState.AddModelError("Name", "Color alredy exist.");
            }
            if (ModelState.IsValid)
            {
                var objColor = db.Colors.Single(c => c.IID == id) ?? new Color();

                objColor.Name = model.Name;
                objColor.Code = model.Code;
                objColor.IsRemoved = model.IsRemoved;
             
                objColor.ModifiedBy = 1;
                objColor.ModifiedDate = DateTime.Now;

                db.Entry(objColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexDelete(int? iid)
        {
            Color color = db.Colors.Find(iid);
            color.IsRemoved = true;
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
