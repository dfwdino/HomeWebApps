using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    public class AutoController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: Autoes
        public ActionResult Index()
        {
            var autoes = db.Autoes.Include(a => a.CreateModifyLog).Include(a => a.User);
            return View(autoes.ToList());
        }

        // GET: Autoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Autoes/Create
        public ActionResult Create()
        {
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
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
                db.Autoes.Add(auto);
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
            Auto auto = db.Autoes.Find(id);
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
            Auto auto = db.Autoes.Find(id);
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
            Auto auto = db.Autoes.Find(id);
            db.Autoes.Remove(auto);
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
