﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    public class MilesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: Miles
        public ActionResult Index(int id)
        {
            var miles = db.Miles.Where(m => m.AutoID == id).Include(m => m.Station).Include(m => m.CreateModifyLog);
            return View(miles.ToList());
        }

        // GET: Miles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mile mile = db.Miles.Find(id);
            if (mile == null)
            {
                return HttpNotFound();
            }
            return View(mile);
        }

        // GET: Miles/Create
        public ActionResult Create(int id)
        {
            
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Name");
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID");
            return View(new Models.MilesAddModel() {AutoID = id,GasDate = DateTime.Now});
        }

        // POST: Miles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MilesID,Deleted,ModfiyID,AutoID,GasDate,TotalGallons,TotalPrice,TotalMilesDriven,EngineRunTime,StationID")] Mile mile)
        {
            if (ModelState.IsValid)
            {
                db.Miles.Add(mile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Name", mile.StationID);
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", mile.ModfiyID);
            return View(mile);
        }

        // GET: Miles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mile mile = db.Miles.Find(id);
            if (mile == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Name", mile.StationID);
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", mile.ModfiyID);
            return View(mile);
        }

        // POST: Miles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MilesID,Deleted,ModfiyID,AutoID,GasDate,TotalGallons,TotalPrice,TotalMilesDriven,EngineRunTime,StationID")] Mile mile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Name", mile.StationID);
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", mile.ModfiyID);
            return View(mile);
        }

        // GET: Miles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mile mile = db.Miles.Find(id);
            if (mile == null)
            {
                return HttpNotFound();
            }
            return View(mile);
        }

        // POST: Miles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mile mile = db.Miles.Find(id);
            db.Miles.Remove(mile);
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
