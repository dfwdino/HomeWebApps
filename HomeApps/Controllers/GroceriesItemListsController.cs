﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeApps;
using HomeApps.Infrastructure;

namespace HomeApps.Controllers
{
    [Access]
    public class GroceriesItemListsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: GroceriesItemLists
        public ActionResult Index()
        {
            var itemLists = db.ItemLists
                .OrderBy(f => f.Item.ItemName)
                .Include(i => i.Item)
                .Include(i => i.SizeType)
                .Include(i => i.Store);
            return View(itemLists.Where(f => f.GotItem == false).ToList());
        }

        public ActionResult ShowAllItems(bool sortbydate = false)
        {
            List<ItemList> itemLists = db.ItemLists
                .OrderByDescending(f => f.DateGot)
                .Include(i => i.Item)
                .Include(i => i.SizeType)
                .Include(i => i.Store)
                .Where(f => f.Item.IsDeleted == false && f.GotItem == true)
                .ToList()
                .GroupBy(f => f.Item.ItemName)
                .Select(f => f.First())
                .Select(f => f)
                .Distinct()
                .ToList();

            return View(itemLists.ToList());
        }

        // GET: GroceriesItemLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return HttpNotFound();
            }
            return View(itemList);
        }

        // GET: GroceriesItemLists/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            ViewBag.SizeTypeID = new SelectList(db.SizeTypes, "SizeTypeID", "SizeTypeName");
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName");
        
            return View();
        }

        // POST: GroceriesItemLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemList itemList)
        {
            try
            {
                var FoundItem = db.Items
                    .Where(f => f.ItemName == itemList.Item.ItemName)
                    .FirstOrDefault();

                bool IsOnList = false;

                if (FoundItem == null)
                {
                    itemList.Item.ItemName = itemList.Item.ItemName.ToTileCase();
                }
                else
                {
                    IsOnList = db.ItemLists.Where(f => f.ItemID == FoundItem.ItemID && f.GotItem == false).Count() > 0;
                   
                }

                if (IsOnList)
                {
                    ViewBag.CreatedItem = true;
                    ViewData["CreatedItem"] = "true" ;
                    return RedirectToAction("Create");
                }
                
                
                itemList.DateAdded = DateTime.Now;
                itemList.Item.KidsStillLike = true;

                db.ItemLists.Add(itemList);
                db.SaveChanges();
                ViewBag.CreatedItem = true;
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", itemList.ItemID);
                ViewBag.SizeTypeID = new SelectList(
                    db.SizeTypes.OrderByDescending(f => f.SizeTypeName),
                    "SizeTypeID",
                    "SizeTypeName",
                    itemList.SizeTypeID
                );
                ViewBag.StoreID = new SelectList(
                    db.Stores.OrderByDescending(f => f.StoreName),
                    "StoreID",
                    "StoreName",
                    itemList.StoreID
                );
                return View(itemList);
            }
        }

        // GET: GroceriesItemLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", itemList.ItemID);
            ViewBag.SizeTypeID = new SelectList(
                db.SizeTypes,
                "SizeTypeID",
                "SizeTypeName",
                itemList.SizeTypeID
            );
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", itemList.StoreID);
            return View(itemList);
        }

        // POST: GroceriesItemLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include = "ItemListID,ItemID,StoreID,GotItem,NumberOfItems,SizeTypeID,DateAdded,DateGot"
            )]
                ItemList itemList
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", itemList.ItemID);
            ViewBag.SizeTypeID = new SelectList(
                db.SizeTypes.OrderByDescending(f => f.SizeTypeName),
                "SizeTypeID",
                "SizeTypeName",
                itemList.SizeTypeID
            );
            ViewBag.StoreID = new SelectList(
                db.Stores.OrderByDescending(f => f.StoreName),
                "StoreID",
                "StoreName",
                itemList.StoreID
            );
            return View(itemList);
        }

        // GET: GroceriesItemLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return HttpNotFound();
            }
            return View(itemList);
        }

        // POST: GroceriesItemLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemList itemList = db.ItemLists.Find(id);
            db.ItemLists.Remove(itemList);
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
