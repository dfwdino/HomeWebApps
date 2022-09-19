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
    public class SizeTypesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: SizeTypes
        public ActionResult Index()
        {
            return View(db.SizeTypes.OrderBy(mm => mm.SizeTypeName).ToList());
        }

        // GET: SizeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeType sizeType = db.SizeTypes.Find(id);
            if (sizeType == null)
            {
                return HttpNotFound();
            }
            return View(sizeType);
        }

        // GET: SizeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SizeTypeID,SizeTypeName,IsDeleted")] SizeType sizeType)
        {
            if (ModelState.IsValid)
            {
                db.SizeTypes.Add(sizeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sizeType);
        }

        // GET: SizeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeType sizeType = db.SizeTypes.Find(id);
            if (sizeType == null)
            {
                return HttpNotFound();
            }
            return View(sizeType);
        }

        // POST: SizeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SizeTypeID,SizeTypeName,IsDeleted")] SizeType sizeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sizeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sizeType);
        }

        // GET: SizeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeType sizeType = db.SizeTypes.Find(id);
            if (sizeType == null)
            {
                return HttpNotFound();
            }
            return View(sizeType);
        }

        // POST: SizeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SizeType sizeType = db.SizeTypes.Find(id);
            db.SizeTypes.Remove(sizeType);
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
