using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeApps;

namespace HomeApps.Controllers
{
    public class ChoreTimeTypesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: ChoreTimeTypes
        public ActionResult Index()
        {
            return View(db.ChoreTimeTypes.ToList());
        }

        // GET: ChoreTimeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoreTimeType choreTimeType = db.ChoreTimeTypes.Find(id);
            if (choreTimeType == null)
            {
                return HttpNotFound();
            }
            return View(choreTimeType);
        }

        // GET: ChoreTimeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChoreTimeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ChoreTimeTypeID,ChoreTime,IsDeleted")] ChoreTimeType choreTimeType
        )
        {
            if (ModelState.IsValid)
            {
                db.ChoreTimeTypes.Add(choreTimeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(choreTimeType);
        }

        // GET: ChoreTimeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoreTimeType choreTimeType = db.ChoreTimeTypes.Find(id);
            if (choreTimeType == null)
            {
                return HttpNotFound();
            }
            return View(choreTimeType);
        }

        // POST: ChoreTimeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ChoreTimeTypeID,ChoreTime,IsDeleted")] ChoreTimeType choreTimeType
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(choreTimeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(choreTimeType);
        }

        // GET: ChoreTimeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoreTimeType choreTimeType = db.ChoreTimeTypes.Find(id);
            if (choreTimeType == null)
            {
                return HttpNotFound();
            }
            return View(choreTimeType);
        }

        // POST: ChoreTimeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChoreTimeType choreTimeType = db.ChoreTimeTypes.Find(id);
            db.ChoreTimeTypes.Remove(choreTimeType);
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
