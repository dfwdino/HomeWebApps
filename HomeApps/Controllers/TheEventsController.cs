using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeApps;
using HomeApps.Models;

namespace HomeApps.Controllers
{
    public class TheEventsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: TheEvents
        public ActionResult Index()
        {
            return View(db.TheEvents.ToList());
        }

        // GET: TheEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheEvent theEvent = db.TheEvents.Find(id);
            if (theEvent == null)
            {
                return HttpNotFound();
            }
            return View(theEvent);
        }

        // GET: TheEvents/Create
        public ActionResult Create()
        {
            UserViewModel userViewModel = Session["_CurrentUser"] as UserViewModel;

            ViewBag.GivingPerson = new SelectList(db.UsersPeoples.Where(m => m.User.FirstName.Contains(userViewModel.FirstName)), "UserID", "PersonName");
            ViewBag.RevelivingPerson = new SelectList(db.UsersPeoples.Where(m => m.User.FirstName.Contains(userViewModel.FirstName)), "UserID", "PersonName");
            ViewBag.ActionsDone = new SelectList(db.Actions, "ActionID", "Name");

            return View(new TheEventCreate());
        }

        // POST: TheEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,DateOfEvent,DateofEventOffSet,IsDeleted,EventName")] TheEvent theEvent)
        {
            if (ModelState.IsValid)
            {
                db.TheEvents.Add(theEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theEvent);
        }

        // GET: TheEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheEvent theEvent = db.TheEvents.Find(id);
            if (theEvent == null)
            {
                return HttpNotFound();
            }
            return View(theEvent);
        }

        // POST: TheEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,DateOfEvent,DateofEventOffSet,IsDeleted,EventName")] TheEvent theEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theEvent);
        }

        // GET: TheEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheEvent theEvent = db.TheEvents.Find(id);
            if (theEvent == null)
            {
                return HttpNotFound();
            }
            return View(theEvent);
        }

        // POST: TheEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheEvent theEvent = db.TheEvents.Find(id);
            db.TheEvents.Remove(theEvent);
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
