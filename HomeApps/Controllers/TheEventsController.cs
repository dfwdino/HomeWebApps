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
using HomeApps.Infrastructure;

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


            TheEventDetails eventDetails = new TheEventDetails() {DateOfEvent = theEvent.DateOfEvent.ToShortDateString(), EventName = theEvent.EventName };

            UserViewModel user = (UserViewModel)this.Session["_CurrentUser"];

             List<EventAction> eventactions = db.EventActions.Where(m => m.EventID == id)
                                                            .OrderBy(m => new { m.GivingPersonID, m.ReveivingPersonID })
                                                        .ToList();
            GroupAction tempEA = new GroupAction();
            foreach (var item in eventactions)
            {
                if(tempEA.Giving == null)
                {
                    tempEA.Giving = item.UsersPeople.PersonName;
                    tempEA.Recving = item.UsersPeople1.PersonName;
                    tempEA.Action = item.Action.Name;
                }
                else if(tempEA.Giving == item.UsersPeople.PersonName && tempEA.Recving == item.UsersPeople1.PersonName)
                {
                    tempEA.Action += ", " + item.Action.Name;
                }
                else
                {
                    eventDetails.Actions.Add(tempEA);
                    tempEA = new GroupAction();
                    tempEA.Giving = item.UsersPeople.PersonName;
                    tempEA.Recving = item.UsersPeople1.PersonName;
                    tempEA.Action = item.Action.Name;

                }
                

            }
            eventDetails.Actions.Add(tempEA);

            return View(eventDetails);
        }

        // GET: TheEvents/Create
        public ActionResult Create()
        {
            UserViewModel userViewModel = Session["_CurrentUser"] as UserViewModel;

            ViewBag.People = new SelectList(db.UsersPeoples.OrderBy(m => m.PersonName), "UsersPersonID", "PersonName");
            ViewBag.ActionsDone = this.db.Actions.OrderBy(m => m.Name).ToList();
            ViewBag.GivingPersonID = new SelectList(db.UsersPeoples.OrderBy(m => m.PersonName), "UsersPersonID", "PersonName");



            return View(new EventCreateModel());
        }

        // POST: TheEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreateModel theEvent)
        {

            if (ModelState.IsValid)
            {
                UserViewModel user = null;
                if (user == null)
                {
                    user = ((UserViewModel)this.Session["_CurrentUser"]);
                }


                TheEvent currentEvent = new TheEvent { EventName = theEvent.EventName, DateOfEvent = Convert.ToDateTime(theEvent.DateOfEvent) };

                db.TheEvents.Add(currentEvent);
                db.SaveChanges();

                foreach (var eventAction in theEvent.EventActions)
                {
                    foreach (var item in eventAction.ActionID.Where(m => m != "false"))
                    {
                        EventAction ac = new EventAction();

                        ac.ActionID = Convert.ToInt32(item);
                        ac.GivingPersonID = Convert.ToInt32(eventAction.GivingPersonID);
                        ac.ReveivingPersonID = Convert.ToInt32(eventAction.ReveivingPersonID);
                        ac.EventID = currentEvent.EventID;
                        ac.OwnerID = user.UserID;

                        db.EventActions.Add(ac);
                    }

                    
                }


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
