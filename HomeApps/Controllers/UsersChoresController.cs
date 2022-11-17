using HomeApps.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    public class UsersChoresController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: UsersChores
        public ActionResult Index()
        {
            var StartOfTheWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);

            var usersChores2 = db.UsersChores.Include(u => u.Chore).Include(u => u.ChoreTimeType).Include(u => u.User)
                .Where(ff => ff.EndDateChore <= SqlFunctions.CurrentTimestamp() || ff.EndDateChore == null)
                .OrderBy(ff => ff.UserID).ThenBy(ff => ff.ChoreTimeTypeID)
                .GroupJoin(db.UsersDoneChores, udc => udc.UserChoreID, uc => uc.UserChoreID, (uc, udc) => new { UC = uc, UDC = udc})
                .ToList()
                .Select(mm => new
                {
                    mm.UC.Chore.ChoreName,
                    mm.UC.ChoreDayTimeType.DayTimeType,
                    mm.UC.ChoreTimeType.ChoreTime,
                    mm.UDC.OrderByDescending(m => m.DateDone).FirstOrDefault()?.DateDone,
                    mm.UC.User.Name,
                    WeeklyDue = (DateTime.Now.Subtract(mm.UC.StartDateChore)).Days % 7 == 0,
                    mm.UC.StartDateChore
                    ,mm.UC.UserChoreID
                })
                .ToList();





            List<PersonChore> personChores = new List<PersonChore>();


            foreach (var person in usersChores2)
            {

                personChores.Add(new PersonChore { ChoreDayTimeType = person.DayTimeType, ChoreDone = person.DateDone >= StartOfTheWeek ? person.DateDone : null, ChoreName = person.ChoreName, ChoreTimeType = person.ChoreTime, PersonName = person.Name
                                    , WeeklyDue = person.WeeklyDue, StartDateChore = person.StartDateChore, UserChoreID = person.UserChoreID
                });
            }


            return View(personChores);
        }

        [HttpPost]
        public void FinishChore(int choreUserID)
        {
            db.UsersDoneChores.Add(new UsersDoneChore {UserChoreID = choreUserID,  DateDone = DateTime.Now, IsDeleted = false });
            db.SaveChanges();
        }

        // GET: UsersChores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersChore usersChore = db.UsersChores.Find(id);
            if (usersChore == null)
            {
                return HttpNotFound();
            }
            return View(usersChore);
        }

        // GET: UsersChores/Create
        public ActionResult Create()
        {
            ViewBag.ChoreID = new SelectList(db.Chores, "ChoreID", "ChoreName");
            ViewBag.ChoreTimeTypeID = new SelectList(db.ChoreTimeTypes, "ChoreTimeTypeID", "ChoreTime");
            ViewBag.ChoreDayTimeTypeID = new SelectList(db.ChoreDayTimeTypes, "ChoreDayTimeTypeID", "DayTimeType");
            ViewBag.UserID = new SelectList(db.User1, "UserID", "Name");

            UsersChore usersChore = new UsersChore();
            usersChore.StartDateChore = DateTime.Now;

            return View(usersChore);
        }

        // POST: UsersChores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersChore usersChore)
        {
            if (ModelState.IsValid)
            {
                db.UsersChores.Add(usersChore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChoreID = new SelectList(db.Chores, "ChoreID", "ChoreName", usersChore.ChoreID);
            ViewBag.ChoreTimeTypeID = new SelectList(db.ChoreTimeTypes, "ChoreTimeTypeID", "ChoreTime", usersChore.ChoreTimeTypeID);
            ViewBag.ChoreDayTimeTypeID = new SelectList(db.ChoreDayTimeTypes, "ChoreDayTimeTypeID", "DayTimeType", usersChore.ChoreDayTimeTypeID);
            ViewBag.UserID = new SelectList(db.User1, "UserID", "Name", usersChore.UserID);
            return View(usersChore);
        }

        // GET: UsersChores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersChore usersChore = db.UsersChores.Find(id);
            if (usersChore == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChoreID = new SelectList(db.Chores, "ChoreID", "ChoreName", usersChore.ChoreID);
            ViewBag.ChoreTimeTypeID = new SelectList(db.ChoreTimeTypes, "ChoreTimeTypeID", "ChoreTime", usersChore.ChoreTimeTypeID);
            ViewBag.ChoreDayTimeTypeID = new SelectList(db.ChoreDayTimeTypes, "ChoreDayTimeTypeID", "DayTimeType", usersChore.ChoreDayTimeTypeID);
            ViewBag.UserID = new SelectList(db.User1, "UserID", "Name", usersChore.UserID);
            return View(usersChore);
        }

        // POST: UsersChores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserChoreID,UserID,ChoreID,IsDeleted,ChoreTimeTypeID,StartDateChore,IsDone,EndDateChore")] UsersChore usersChore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersChore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChoreID = new SelectList(db.Chores, "ChoreID", "ChoreName", usersChore.ChoreID);
            ViewBag.ChoreTimeTypeID = new SelectList(db.ChoreTimeTypes, "ChoreTimeTypeID", "ChoreTime", usersChore.ChoreTimeTypeID);
            ViewBag.ChoreDayTimeTypeID = new SelectList(db.ChoreDayTimeTypes, "ChoreDayTimeTypeID", "DayTimeType", usersChore.ChoreDayTimeTypeID);
            ViewBag.UserID = new SelectList(db.User1, "UserID", "Name", usersChore.UserID);
            return View(usersChore);
        }

        // GET: UsersChores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersChore usersChore = db.UsersChores.Find(id);
            if (usersChore == null)
            {
                return HttpNotFound();
            }
            return View(usersChore);
        }

        // POST: UsersChores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersChore usersChore = db.UsersChores.Find(id);
            db.UsersChores.Remove(usersChore);
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