using HomeApps.Infrastructure;
using HomeApps.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    [Access]
    public class AutosController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();
        private UserViewModel user;

        // GET: Autoes
        public ActionResult Index()
        {
            user = ((UserViewModel)this.Session["_CurrentUser"]);

            var autoes = db.Autos.Where(m => m.Deleted == false).Where(m => m.UserID == user.UserID);
            return View(autoes.ToList());
        }

        // GET: Autoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Autoes/Create
        public ActionResult Create()
        {

            if (user == null)
            {
                user = ((UserViewModel)this.Session["_CurrentUser"]);
            }

            return View();
        }

        // POST: Autoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutoID,Deleted,ModfiyID,AutoName,UserID")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    user = ((UserViewModel)this.Session["_CurrentUser"]);
                }

                CreateModifyLog cml = new CreateModifyLog();
                cml.CreatedBy = user.UserID;
                cml.CreatedOn = DateTime.Now;

                db.CreateModifyLogs.Add(cml);
                db.SaveChanges();
                auto.CreateModifyLog = cml;
                                
                auto.UserID = user.UserID;
                db.Autos.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", auto.ModfiyID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", auto.UserID);
            return View(auto);
        }

        // GET: Autoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", auto.ModfiyID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", auto.UserID);
            return View(auto);
        }

        // POST: Autoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutoID,Deleted,ModfiyID,AutoName,UserID")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", auto.ModfiyID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", auto.UserID);
            return View(auto);
        }

        // GET: Autoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Autoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto auto = db.Autos.Find(id);
            //db.Autos.Remove(auto);
            auto.Deleted = true;
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
