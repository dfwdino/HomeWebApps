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
    public class EventPeoplesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: EventPeoples
        public ActionResult Index()
        {
            var eventPeoples = db.EventPeoples.Include(e => e.User);
            return View(eventPeoples.ToList());
        }

        // GET: EventPeoples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventPeople eventPeople = db.EventPeoples.Find(id);
            if (eventPeople == null)
            {
                return HttpNotFound();
            }
            return View(eventPeople);
        }

        // GET: EventPeoples/Create
        public ActionResult Create()
        {
            ViewBag.EntryUserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: EventPeoples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartyPersonID,EntryUserID,PartyPersonName,IsDeleted")] EventPeople eventPeople)
        {
            if (ModelState.IsValid)
            {
                db.EventPeoples.Add(eventPeople);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntryUserID = new SelectList(db.Users, "UserID", "FirstName", eventPeople.EntryUserID);
            return View(eventPeople);
        }

        // GET: EventPeoples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventPeople eventPeople = db.EventPeoples.Find(id);
            if (eventPeople == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntryUserID = new SelectList(db.Users, "UserID", "FirstName", eventPeople.EntryUserID);
            return View(eventPeople);
        }

        // POST: EventPeoples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartyPersonID,EntryUserID,PartyPersonName,IsDeleted")] EventPeople eventPeople)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventPeople).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntryUserID = new SelectList(db.Users, "UserID", "FirstName", eventPeople.EntryUserID);
            return View(eventPeople);
        }

        // GET: EventPeoples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventPeople eventPeople = db.EventPeoples.Find(id);
            if (eventPeople == null)
            {
                return HttpNotFound();
            }
            return View(eventPeople);
        }

        // POST: EventPeoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventPeople eventPeople = db.EventPeoples.Find(id);
            db.EventPeoples.Remove(eventPeople);
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
