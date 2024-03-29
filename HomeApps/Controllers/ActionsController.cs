﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using HomeApps;
using HomeApps.Model;

namespace HomeApps.Controllers
{
    public class ActionsController : Controller
    {
        private readonly HomeAppsEntities db = new HomeAppsEntities();

        // GET: Actions
        public ActionResult Index()
        {
            var actions = this.db.Actions.OrderBy(m => m.Name);
            return View(actions.ToList());
        }

        // GET: Actions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Action action = db.Actions.Find(id);
            if (action == null)
            {
                return HttpNotFound();
            }
            return View(action);
        }

        // GET: Actions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string action)
        {
            if (ModelState.IsValid)
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                Action newaction = new Action();
                newaction.Name = textInfo.ToTitleCase(action);

                this.db.Actions.Add(newaction);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(action);
        }

        // GET: Actions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Action action = db.Actions.Find(id);

            TheEventAction theEventAction = new TheEventAction
            {
                ActionID = action.ActionID,
                ActionName = action.Name
            };

            if (action == null)
            {
                return HttpNotFound();
            }

            ViewBag.ActionID = new SelectList(
                db.EventActions,
                "EventActionsID",
                "EventActionsID",
                action.ActionID
            );
            return View(theEventAction);
        }

        // POST: Actions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(TheEventAction theeventaction)
        {
            if (ModelState.IsValid)
            {
                Action action = db.Actions.Find(theeventaction.ActionID);

                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                action.Name = textInfo.ToTitleCase(theeventaction.ActionName);

                db.Entry(action).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActionID = new SelectList(
                db.EventActions,
                "EventActionsID",
                "EventActionsID",
                theeventaction.ActionID
            );
            return View(theeventaction);
        }

        // GET: Actions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Action action = db.Actions.Find(id);
            if (action == null)
            {
                return HttpNotFound();
            }
            return View(action);
        }

        // POST: Actions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Action action = db.Actions.Find(id);
            //db.Actions.Remove(action);
            action.IsDeleted = false;
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
