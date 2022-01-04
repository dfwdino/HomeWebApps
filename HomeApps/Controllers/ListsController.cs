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
    public class ListsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: Lists
        public ActionResult Index()
        {
            var lists = db.Lists.Include(l => l.Item).Include(l => l.Store).Include(l => l.User);
            return View(lists.ToList());
        }

        // GET: Lists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.Lists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: Lists/Create
        public ActionResult Create()
        {
            //ViewBag.FoodItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.StoreID = new SelectList(db.Stores.Where(m => m.Deleted == false), "StoreID", "Name").Append(new SelectListItem() { Text = "Select Store", Selected = true, Value = "3" });
            ViewBag.UserID = new SelectList(db.Users.Where(m => m.UserID != 1).OrderBy(m => m.FirstName), "UserID", "FirstName");
            return View();
        }

        // POST: Lists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListID,FoodItemID,UserID,StoreID,GotItem,ShowOnAllLists")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Lists.Add(list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreID = new SelectList(db.Stores.Where(m => m.Deleted == false), "StoreID", "Name", list.StoreID).Append(new SelectListItem() { Text = "Select Store", Selected = true, Value = "3" }); ;
            ViewBag.UserID = new SelectList(db.Users.Where(m => m.UserID != 1).OrderBy(m => m.FirstName), "UserID", "FirstName");
            return View(list);
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.Lists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }

            ViewBag.StoreID = new SelectList(db.Stores.Where(m => m.Deleted == false), "StoreID", "Name", list.StoreID).Append(new SelectListItem() { Text = "Select Store", Selected = true, Value = "3" }); ;
            ViewBag.UserID = new SelectList(db.Users.Where(m => m.UserID != 1).OrderBy(m => m.FirstName), "UserID", "FirstName");
            return View(list);
        }

        // POST: Lists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListID,FoodItemID,UserID,StoreID,GotItem,ShowOnAllLists")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodItemID = new SelectList(db.Items, "ItemID", "Name", list.FoodItemID);
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "Name", list.StoreID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", list.UserID);
            return View(list);
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.Lists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List list = db.Lists.Find(id);
            db.Lists.Remove(list);
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
