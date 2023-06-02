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
    public class CameraModelsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: CameraModels
        public ActionResult Index()
        {
            var cameraModels = db.CameraModels.Include(c => c.GenderType);
            return View(cameraModels.ToList());
        }

        // GET: CameraModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CameraModel cameraModel = db.CameraModels.Find(id);
            if (cameraModel == null)
            {
                return HttpNotFound();
            }
            return View(cameraModel);
        }

        // GET: CameraModels/Create
        public ActionResult Create()
        {
            ViewBag.CameraModelGender = new SelectList(db.GenderTypes, "GenderID", "GenderType1");
            return View();
        }

        public ActionResult CreateModelNotes()
        {
            ViewBag.CameraModelID = new SelectList(
                db.CameraModels,
                "CameraModelID",
                "CameraModelName"
            );
            return View();
        }

        [HttpPost]
        public ActionResult CreateModelNotes(CameraModelNote cameraModelNote)
        {
            var asdf = new CameraModelNote
            {
                DateOfNotes = cameraModelNote.DateOfNotes,
                Notes = cameraModelNote.Notes,
                CameraModelID = cameraModelNote.CameraModelID
            };
            db.CameraModelNotes.Add(cameraModelNote);
            db.SaveChanges();
            return RedirectToAction("GetModelNotes");
        }

        public ActionResult GetModelNotes()
        {
            return View(db.CameraModelNotes.OrderByDescending(mm => mm.DateOfNotes));
        }

        // POST: CameraModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(
                Include = "CameraModelID,CameraModelName,CameraModelGender,Deleted,AllNudes,AllBonjour,AllTFP"
            )]
                CameraModel cameraModel
        )
        {
            if (ModelState.IsValid)
            {
                db.CameraModels.Add(cameraModel);
                db.SaveChanges();
                return RedirectToAction("/Index");
            }

            ViewBag.CameraModelGender = new SelectList(
                db.GenderTypes,
                "GenderID",
                "GenderType1",
                cameraModel.CameraModelGender
            );
            return View(cameraModel);
        }

        // GET: CameraModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CameraModel cameraModel = db.CameraModels.Find(id);
            if (cameraModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CameraModelGender = new SelectList(
                db.GenderTypes,
                "GenderID",
                "GenderType1",
                cameraModel.CameraModelGender
            );
            return View(cameraModel);
        }

        // POST: CameraModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include = "CameraModelID,CameraModelName,CameraModelGender,Deleted,AllNudes,AllBonjour,AllTFP"
            )]
                CameraModel cameraModel
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(cameraModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CameraModelGender = new SelectList(
                db.GenderTypes,
                "GenderID",
                "GenderType1",
                cameraModel.CameraModelGender
            );
            return View(cameraModel);
        }

        // GET: CameraModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CameraModel cameraModel = db.CameraModels.Find(id);
            if (cameraModel == null)
            {
                return HttpNotFound();
            }
            return View(cameraModel);
        }

        // POST: CameraModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CameraModel cameraModel = db.CameraModels.Find(id);
            db.CameraModels.Remove(cameraModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateGenderType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGenderType(GenderType genderType)
        {
            if (
                !genderType.Equals(
                    db.GenderTypes.Any(m => m.GenderType1 == genderType.GenderType1.Trim())
                )
            )
            {
                db.GenderTypes.Add(new GenderType { GenderType1 = genderType.GenderType1 });
                db.SaveChanges();
            }

            return RedirectToAction("GetGenderTypes");
        }

        public ActionResult GetGenderTypes()
        {
            return View(db.GenderTypes);
        }

        public ActionResult CreateWebSite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWebSite(Website website)
        {
            if (!website.Equals(db.Websites.Any(m => m.WebsiteName == website.WebsiteName.Trim())))
            {
                db.Websites.Add(new Website { WebsiteName = website.WebsiteName });
                db.SaveChanges();
            }

            return RedirectToAction("GetWebSites");
        }

        public ActionResult GetWebSites()
        {
            return View(db.Websites);
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
