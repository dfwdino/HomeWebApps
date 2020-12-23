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
    public class SocialSitesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: SocialSites
        public ActionResult Index()
        {
            return View(db.SocialSites.ToList());
        }

        // GET: SocialSites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialSite socialSite = db.SocialSites.Find(id);
            if (socialSite == null)
            {
                return HttpNotFound();
            }
            return View(socialSite);
        }

        // GET: SocialSites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialSites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocalTypeID,SocalSiteName")] SocialSite socialSite)
        {
            if (ModelState.IsValid)
            {
                db.SocialSites.Add(socialSite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialSite);
        }

        // GET: SocialSites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialSite socialSite = db.SocialSites.Find(id);
            if (socialSite == null)
            {
                return HttpNotFound();
            }
            return View(socialSite);
        }

        // POST: SocialSites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocalTypeID,SocalSiteName")] SocialSite socialSite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialSite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialSite);
        }

        // GET: SocialSites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialSite socialSite = db.SocialSites.Find(id);
            if (socialSite == null)
            {
                return HttpNotFound();
            }
            return View(socialSite);
        }

        // POST: SocialSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialSite socialSite = db.SocialSites.Find(id);
            db.SocialSites.Remove(socialSite);
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
