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
    public class UsersPeoplesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: UsersPeoples
        public ActionResult Index()
        {
            var usersPeoples = db.UsersPeoples.Include(u => u.User).Include(u => u.Gender);
            return View(usersPeoples.ToList());
        }

        // GET: UsersPeoples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersPeople usersPeople = db.UsersPeoples.Find(id);
            if (usersPeople == null)
            {
                return HttpNotFound();
            }
            return View(usersPeople);
        }

        // GET: UsersPeoples/Create
        public ActionResult Create()
        {
            UserViewModel userViewModel = (UserViewModel)this.Session["_CurrentUser"];
            UsersPeople createUser = new UsersPeople();
            createUser.UserID = userViewModel.UserID;

            //ViewBag.UserID = new SelectList(db.Users.Where(m => m.FirstName.Contains(userViewModel.FirstName)).ToList(), "UserID", "FirstName");
            ViewBag.PersonGenderID = new SelectList(db.Genders, "GenderID", "Gender1");

            

            return View(createUser);
        }

        // POST: UsersPeoples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersPeople usersPeople)
        {
            if (ModelState.IsValid)
            {
                db.UsersPeoples.Add(usersPeople);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", usersPeople.UserID);
            ViewBag.PersonGenderID = new SelectList(db.Genders, "GenderID", "Gender1", usersPeople.PersonGenderID);
            return View(usersPeople);
        }

        // GET: UsersPeoples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersPeople usersPeople = db.UsersPeoples.Find(id);
            if (usersPeople == null)
            {
                return HttpNotFound();
            }

            UserViewModel userViewModel = Session["_CurrentUser"] as UserViewModel;

            ViewBag.UserID = new SelectList(db.Users.Where(m => m.FirstName.Contains(userViewModel.FirstName)), "UserID", "FirstName");
            ViewBag.PersonGenderID = new SelectList(db.Genders, "GenderID", "Gender1", usersPeople.PersonGenderID);
            return View(usersPeople);
        }

        // POST: UsersPeoples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsersPersonID,PersonName,PersonGenderID,UserID,Notes")] UsersPeople usersPeople)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersPeople).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            UserViewModel userViewModel = Session["_CurrentUser"] as UserViewModel;

            ViewBag.UserID = new SelectList(db.Users.Where(m => m.FirstName.Contains(userViewModel.FirstName)), "UserID", "FirstName");
            ViewBag.PersonGenderID = new SelectList(db.Genders, "GenderID", "Gender1", usersPeople.PersonGenderID);
            return View(usersPeople);
        }

        // GET: UsersPeoples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersPeople usersPeople = db.UsersPeoples.Find(id);
            if (usersPeople == null)
            {
                return HttpNotFound();
            }
            return View(usersPeople);
        }

        // POST: UsersPeoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersPeople usersPeople = db.UsersPeoples.Find(id);
            db.UsersPeoples.Remove(usersPeople);
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
