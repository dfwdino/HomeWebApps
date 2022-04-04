using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeApps;
using HomeApps.Model;
using HomeApps.Infrastructure;

namespace HomeApps.Controllers
{
    public class ModelPeoplesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: ModelPeoples
        public ActionResult Index()
        {
            return View(db.ModelPeoples.ToList());
        }

        // GET: ModelPeoples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPeople modelPeople = db.ModelPeoples.Find(id);
            
            if (modelPeople == null)
            {
                return HttpNotFound();
            }
            return View(modelPeople);
        }

        // GET: ModelPeoples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelPeoples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelPersonID,Deleted,ModfiyID,FirstName,LastName,Gender,AllNudes,AllBoudoir,AllErotica,Notes,PhoneNumber,Email,FileName")] ModelPeople modelPeople)
        {
            if (ModelState.IsValid)
            {
                db.ModelPeoples.Add(modelPeople);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelPeople);
        }

        // GET: ModelPeoples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPeople modelPeople = db.ModelPeoples.Find(id);

            ViewBag.SocialSites = new SelectList(db.SocialSites.AsEnumerable(), "SocalTypeID", "SocalSiteName");

            if (modelPeople == null)
            {
                return HttpNotFound();
            }
            return View(modelPeople);
        }

        // POST: ModelPeoples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelPersonID,Deleted,ModfiyID,FirstName,LastName,Gender,AllNudes,AllBoudoir,AllErotica,Notes,PhoneNumber,Email,FileName")] ModelPeople modelPeople)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelPeople).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelPeople);
        }

        // GET: ModelPeoples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelPeople modelPeople = db.ModelPeoples.Find(id);
            if (modelPeople == null)
            {
                return HttpNotFound();
            }
            return View(modelPeople);
        }

        // POST: ModelPeoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelPeople modelPeople = db.ModelPeoples.Find(id);
            db.ModelPeoples.Remove(modelPeople);
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
