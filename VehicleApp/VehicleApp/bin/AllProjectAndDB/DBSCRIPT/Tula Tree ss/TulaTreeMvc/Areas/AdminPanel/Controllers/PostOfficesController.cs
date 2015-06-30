using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PagedList;
using Tula.BLL.Basic;
using Tula.DAL;
using Tula.Utilities;
using TulaTreeMvc.Areas.AdminPanel.Models;

namespace TulaTreeMvc.Areas.AdminPanel.Controllers
{
    public class PostOfficesController : Controller
    {
        private DBConnectionString db = new DBConnectionString();

        // GET: AdminPanel/PostOffices
        public ActionResult Index(int? page)
        {
            try
            {
                const int pageSize = 10;
                int pageNumber = (page ?? 1);
                var postOfficeList = db.PostOffices.ToList();

                return View(postOfficeList.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return View("Error", ErrorHelper.GetInstance(ex.Message, ex.StackTrace));
            }

        }
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexDelete(int? iid)
        {
            try
            {
                PostOffice postOffice = db.PostOffices.Find(iid);
                postOffice.IsRemoved = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View("Error", ErrorHelper.GetInstance(ex.Message, ex.StackTrace));
            }

        }

        // GET: AdminPanel/PostOffices/Details/5
        public ActionResult Details(long? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PostOffice postOffice = db.PostOffices.Find(id);
                if (postOffice == null)
                {
                    return HttpNotFound();
                }
                return View(postOffice);
            }
            catch (Exception ex)
            {

                return View("Error", ErrorHelper.GetInstance(ex.Message, ex.StackTrace));
            }

        }

        // GET: AdminPanel/PostOffices/Create
        public ActionResult Create()
        {
            try
            {
                var countries = db.Countries.Where(x => x.IsRemoved == false).OrderBy(x => x.Name);
                ViewBag.CountrySelectList = new SelectList(countries, "IID", "Name");
                return View();
            }
            catch (Exception ex)
            {

                return View("Error", ErrorHelper.GetInstance(ex.Message, ex.StackTrace));
            }


        }

        // POST: AdminPanel/PostOffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostOfficeViewModel model)
        {
            try
            {
                var isCountryAlredyNameExist = db.PostOffices.AsEnumerable().Count(c => (!string.IsNullOrWhiteSpace(c.Name) && c.Name == model.Name) || (c.Name.IsNullOrWhiteSpace() && c.PoliceStationID == model.PoliceStationID)) > 0;

                if (isCountryAlredyNameExist)
                {
                    ModelState.AddModelError("Name", "Post office name " + model.Name + " alredy exist.");
                }
                var postOffice = new PostOffice()
                {
                    Name = model.Name,
                    Code = model.Code,
                    CountryID = model.CountryID,
                    DivisionOrStateID = model.DivisionOrStateID,
                    DistrictID = model.DistrictID,
                    PoliceStationID = model.PoliceStationID,
                    IsRemoved = false,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                };


                if (ModelState.IsValid)
                {
                    db.PostOffices.Add(postOffice);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                return View("Error", ErrorHelper.GetInstance(ex.Message, ex.StackTrace));
            }


        }

        // GET: AdminPanel/PostOffices/Edit/5
        public ActionResult Edit(long? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PostOffice postOffice = db.PostOffices.Find(id);
                if (postOffice == null)
                {
                    return HttpNotFound();
                }

                var countries = db.Countries.Where(x => x.IsRemoved == false).OrderBy(x => x.Name);
                ViewBag.CountrySelectList = new SelectList(countries, "IID", "Name", postOffice.CountryID);

                using (var rt = new DivisionOrStateRT())
                {
                    var divOrStateList = rt.GetDistrictOrStateForCountryId(postOffice.CountryID);
                    ViewBag.DivOrStateListItems = new SelectList(divOrStateList, "IID", "Name", postOffice.DivisionOrStateID);

                }
                using (var rt = new DistrictRT())
                {
                    var districtList = rt.GetDistrictByCountryIdAndDivisionOrStateId(postOffice.CountryID,
                        postOffice.DivisionOrStateID);
                    ViewBag.DistrictListItems = new SelectList(districtList, "IID", "Name", postOffice.DistrictID);
                }
                using (var rt = new PoliceStationRT())
                {
                    var districtList = rt.GetAllPoliceStationsByDistrictId(postOffice.DistrictID);
                    ViewBag.PoliceStationListItems = new SelectList(districtList, "IID", "Name", postOffice.DistrictID);
                }


                var model = new PostOfficeViewModel()
                {
                    Name = postOffice.Name,
                    IsRemoved = postOffice.IsRemoved,
                    Code = postOffice.Code,
                    PoliceStationID = postOffice.PoliceStationID,
                    CountryID = postOffice.CountryID,
                    DistrictID = postOffice.DistrictID,
                    DivisionOrStateID = postOffice.DivisionOrStateID
                };

                return View(model);
            }
            catch (Exception ex)
            {

                return View("Error", ErrorHelper.GetInstance(ex.Message, ex.StackTrace));
            }

        }

        // POST: AdminPanel/PostOffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostOfficeViewModel model, long id)
        {
            try
            {
                var isCountryAlredyNameExist = db.PostOffices.AsEnumerable().Count(c => ((!c.Name.IsNullOrWhiteSpace() && c.Name == model.Name) || (c.Name.IsNullOrWhiteSpace() && c.PoliceStationID == model.PoliceStationID)) && c.IID != id) > 0;

                if (isCountryAlredyNameExist)
                {
                    ModelState.AddModelError("Name", "Post office name " + model.Name + " alredy exist.");
                }
                PostOffice postOffice = db.PostOffices.Find(id);
                if (postOffice == null)
                {
                    return HttpNotFound();
                }

                if (ModelState.IsValid)
                {
                    postOffice.Name = model.Name;
                    postOffice.Code = model.Code;
                    postOffice.CountryID = model.CountryID;
                    postOffice.DivisionOrStateID = model.DivisionOrStateID;
                    postOffice.DistrictID = model.DistrictID;
                    postOffice.PoliceStationID = model.PoliceStationID;
                    postOffice.IsRemoved = model.IsRemoved;
                    postOffice.ModifiedBy = 1;
                    postOffice.ModifiedDate = DateTime.Now;

                    db.Entry(postOffice).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                return View("Error", ErrorHelper.GetInstance(ex.Message, ex.StackTrace));
            }

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
