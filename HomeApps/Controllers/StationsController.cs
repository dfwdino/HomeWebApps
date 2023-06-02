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
    public class StationsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();
        private User user;

        // GET: Stations
        public ActionResult Index()
        {
            var stations = db.Stations
                .Where(m => m.Deleted == false)
                .OrderBy(m => m.Name)
                .Include(s => s.CreateModifyLog);
            return View(stations.ToList());
        }

        [HttpPost]
        public JsonResult CreateWebStation(string station)
        {
            Station newstation = new Station() { Name = station };

            if (user == null)
            {
                user = ((User)this.Session["_CurrentUser"]);
            }

            if (user == null)
            {
                return Json(new { IsCreated = false, ErrorMessage = "User is not logged in" });
            }

            CreateModifyLog cml = new CreateModifyLog();
            cml.CreatedBy = user.UserID;
            cml.CreatedOn = DateTime.Now;

            db.CreateModifyLogs.Add(cml);
            db.SaveChanges();
            newstation.CreateModifyLog = cml;

            db.Stations.Add(newstation);
            db.SaveChanges();

            return Json(new { IsCreated = true, NewStationID = newstation.StationID });
        }

        // GET: Stations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // GET: Stations/Create
        public ActionResult Create()
        {
            ViewBag.ModfiyID = new SelectList(
                db.CreateModifyLogs,
                "CreateModifyID",
                "CreateModifyID"
            );
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "StationID,Deleted,ModfiyID,Name")] Station station
        )
        {
            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    user = ((User)this.Session["_CurrentUser"]);
                }

                CreateModifyLog cml = new CreateModifyLog();
                cml.CreatedBy = user.UserID;
                cml.CreatedOn = DateTime.Now;

                db.CreateModifyLogs.Add(cml);
                db.SaveChanges();
                station.CreateModifyLog = cml;

                db.Stations.Add(station);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModfiyID = new SelectList(
                db.CreateModifyLogs,
                "CreateModifyID",
                "CreateModifyID",
                station.ModfiyID
            );
            return View(station);
        }

        // GET: Stations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModfiyID = new SelectList(
                db.CreateModifyLogs,
                "CreateModifyID",
                "CreateModifyID",
                station.ModfiyID
            );
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "StationID,Deleted,ModfiyID,Name")] Station station
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(station).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModfiyID = new SelectList(
                db.CreateModifyLogs,
                "CreateModifyID",
                "CreateModifyID",
                station.ModfiyID
            );
            return View(station);
        }

        // GET: Stations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Station station = db.Stations.Find(id);
            station.Deleted = true;
            //db.Stations.Remove(station);

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
