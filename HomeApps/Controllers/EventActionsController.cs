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
    public class EventActionsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: EventActions
        public ActionResult Index()
        {
            var eventActions = db.EventActions.Include(e => e.User).Include(e => e.Event).Include(e => e.EventPeople);
            return View(eventActions.ToList());
        }

        // GET: EventActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventAction eventAction = db.EventActions.Find(id);
            if (eventAction == null)
            {
                return HttpNotFound();
            }
            return View(eventAction);
        }

        // GET: EventActions/Create
        public ActionResult Create()
        {
            ViewBag.EntryPersonID = new SelectList(db.Users, "UserID", "FirstName");
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            ViewBag.PartyPersonID = new SelectList(db.EventPeoples, "PartyPersonID", "PartyPersonName");
            return View();
        }

        // POST: EventActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActionEventID,EventID,EntryPersonID,PartyPersonID")] EventAction eventAction)
        {
            if (ModelState.IsValid)
            {
                db.EventActions.Add(eventAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntryPersonID = new SelectList(db.Users, "UserID", "FirstName", eventAction.EntryPersonID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventAction.EventID);
            ViewBag.PartyPersonID = new SelectList(db.EventPeoples, "PartyPersonID", "PartyPersonName", eventAction.EventPersonID);
            return View(eventAction);
        }

        // GET: EventActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventAction eventAction = db.EventActions.Find(id);
            if (eventAction == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntryPersonID = new SelectList(db.Users, "UserID", "FirstName", eventAction.EntryPersonID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventAction.EventID);
            ViewBag.PartyPersonID = new SelectList(db.EventPeoples, "PartyPersonID", "PartyPersonName", eventAction.EventPersonID);
            return View(eventAction);
        }

        // POST: EventActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActionEventID,EventID,EntryPersonID,PartyPersonID")] EventAction eventAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntryPersonID = new SelectList(db.Users, "UserID", "FirstName", eventAction.EntryPersonID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventAction.EventID);
            ViewBag.PartyPersonID = new SelectList(db.EventPeoples, "PartyPersonID", "PartyPersonName", eventAction.EventPersonID);
            return View(eventAction);
        }

        // GET: EventActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventAction eventAction = db.EventActions.Find(id);
            if (eventAction == null)
            {
                return HttpNotFound();
            }
            return View(eventAction);
        }

        // POST: EventActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventAction eventAction = db.EventActions.Find(id);
            db.EventActions.Remove(eventAction);
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
