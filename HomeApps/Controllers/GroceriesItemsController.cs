﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeApps;
using HomeApps.Infrastructure;

namespace HomeApps.Controllers
{
    [Access]
    public class GroceriesItemsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: GroceriesItems
        public ActionResult Index()
        {
            return View(
                db.Items.Where(f => f.IsDeleted == false).OrderBy(f => f.ItemName).ToList()
            );
        }

        // GET: GroceriesItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: GroceriesItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroceriesItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ItemID,ItemName,IsDeleted,Notes,IsMSGFree,KidsStillLike")] Item item
        )
        {
            if (ModelState.IsValid)
            {
                item.ItemName = item.ItemName.ToTileCase();
                db.Items.Add(item);
                db.SaveChanges();
                ViewBag.CreatedItem = true;
                return RedirectToAction("Create");
                //return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: GroceriesItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: GroceriesItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ItemID,ItemName,IsDeleted,IsMSGFree,KidsStillLike")] Item item
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: GroceriesItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: GroceriesItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            //db.Items.Remove(item);
            item.IsDeleted = true;
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

        public JsonResult LookUpFoodItem(string term)
        {
            return Json(
                db.Items
                    .Where(m => m.ItemName.Contains(term) && m.IsDeleted == false)
                    .Select(m => new { value = m.ItemName, m.ItemID })
                    .OrderBy(m => m.value),
                JsonRequestBehavior.AllowGet
            );
        }

        public void GotItem(int ItemListID)
        {
            var gotitem = db.ItemLists
                .Where(f => f.ItemListID == ItemListID)
                .OrderByDescending(f => f.DateGot)
                .First();

            bool IsOnList = db.ItemLists.Where(f => f.ItemID == gotitem.ItemID && f.GotItem == false).Count() > 0;

          
            if (gotitem.DateGot != null && IsOnList.Equals(false))
            {
                DateTime dateTime = DateTime.Now;

                db.ItemLists.Add(new ItemList { ItemID = gotitem.ItemID, DateAdded = dateTime });
            }
            else if(IsOnList.Equals(true))
            {
                gotitem.GotItem = true;
                gotitem.DateGot = DateTime.Now;
            }

            db.SaveChanges();
        }
    }
}
