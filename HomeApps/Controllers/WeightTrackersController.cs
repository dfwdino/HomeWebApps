using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeApps;
using HomeApps.Infrastructure;
using HomeApps.Model;
using HomeApps.Models;

namespace HomeApps.Controllers
{
    [Access]
    public class WeightTrackersController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();
        private UserViewModel user;

        // GET: WeightTrackers
        public ActionResult Index()
        {
            user = ((UserViewModel)this.Session["_CurrentUser"]);

            WeightTrackerViewModel weightTrackerViewModel = new WeightTrackerViewModel();

            DateTime dt30days = DateTime.Now.AddDays(-30);
            
            weightTrackerViewModel.BodyWeights = db.WeightTrackers.Include(w => w.User).Where(m => m.UserID == user.UserID).OrderByDescending(m => m.WeightData).ToList();

            if (weightTrackerViewModel.BodyWeights.Where(m => m.WeightData >= dt30days).Count() > 0)
            {
                weightTrackerViewModel.MiniWeight = weightTrackerViewModel.BodyWeights.Where(m => m.WeightData >= dt30days).Min(m => m.WeightAmout);

                weightTrackerViewModel.MaxWeight = weightTrackerViewModel.BodyWeights.Where(m => m.WeightData >= dt30days).Max(m => m.WeightAmout);

                weightTrackerViewModel.AvgWeight = (int)weightTrackerViewModel.BodyWeights.Where(m => m.WeightData >= dt30days).Average(m => m.WeightAmout);
            }

            weightTrackerViewModel.FirstName = weightTrackerViewModel.BodyWeights.FirstOrDefault()?.User.FirstName;

            return View(weightTrackerViewModel);
        }

        // GET: WeightTrackers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightTracker weightTracker = db.WeightTrackers.Find(id);
            if (weightTracker == null)
            {
                return HttpNotFound();
            }
            return View(weightTracker);
        }

        // GET: WeightTrackers/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: WeightTrackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeightID,WeightAmout,WeightData,UserID,Deleted,Notes,WistSize")] WeightTracker weightTracker)
        {
            if (ModelState.IsValid)
            {
                user = ((UserViewModel)this.Session["_CurrentUser"]);
                //weightTracker.User = user;
                weightTracker.UserID = user.UserID;

                db.WeightTrackers.Add(weightTracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", weightTracker.UserID);
            return View(weightTracker);
        }

        // GET: WeightTrackers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightTracker weightTracker = db.WeightTrackers.Find(id);
            if (weightTracker == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", weightTracker.UserID);
            return View(weightTracker);
        }

        // POST: WeightTrackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeightID,WeightAmout,WeightData,UserID,Deleted,Notes,WistSize")] WeightTracker weightTracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weightTracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", weightTracker.UserID);
            return View(weightTracker);
        }

        // GET: WeightTrackers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightTracker weightTracker = db.WeightTrackers.Find(id);
            if (weightTracker == null)
            {
                return HttpNotFound();
            }
            return View(weightTracker);
        }

        // POST: WeightTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeightTracker weightTracker = db.WeightTrackers.Find(id);
            db.WeightTrackers.Remove(weightTracker);
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
