using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeApps;
using HomeApps.Infrastructure;

namespace HomeApps.Controllers
{
    [Access]
    public class ModelsController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: Models
        public ActionResult Index()
        {
            return View(db.Models.Where(m => m.Deleted==false).ToList());
        }

        public ActionResult UploadFileTest()
        {

            return View();
        }

        // GET: Models/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Models/Create
        public ActionResult Create()
        {

            ViewBag.SocialSites = new SelectList(db.SocialSites.AsEnumerable(), "SocalTypeID", "SocalSiteName").Append(new SelectListItem() { Text = "Select Site", Selected = true, Value = "0" });

            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Model model,FormCollection form)
        {

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/uploads"),
                                                   Path.GetFileName(file.FileName));

                        var test = Server.MapPath("~/uploads");

                        if (!System.IO.Directory.Exists(test))
                        {
                            System.IO.Directory.CreateDirectory(test);
                        }

                        file.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }


                var SocialSites = form["SocialSites"].Split(',');
                var SocialSiteURL = form["SocialSiteURL"].Split(',');

                for (int i = 0; i < SocialSites.Length; i++)
                {
                   
                    model.ModelSocialSites.Add(new ModelSocialSite {ModelID=model.ModelID,SocialSiteID= Convert.ToInt16(SocialSites[i]),URL= SocialSiteURL[i] });

                }

                db.Models.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Models/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.SocialSites = new SelectList(db.SocialSites.AsEnumerable(), "SocalTypeID", "SocalSiteName").Append(new SelectListItem() { Text = "Select Site", Selected = true, Value = "0" });

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, Model model, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/uploads"),
                                                   Path.GetFileName(file.FileName));

                        var test = Server.MapPath("~/uploads");

                        if (!System.IO.Directory.Exists(test))
                        {
                            System.IO.Directory.CreateDirectory(test);
                        }

                        file.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                        model.FileName = path;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }


                var SocialSites = form["SocialSites"].Split(',');
                var SocialSiteURL = form["SocialSiteURL"].Split(',');

                

                db.Entry(model).State = EntityState.Modified;

                for (int i = 0; i < SocialSites.Length; i++)
                {

                    model.ModelSocialSites.Add(new ModelSocialSite { ModelID = model.ModelID, SocialSiteID = Convert.ToInt16(SocialSites[i]), URL = SocialSiteURL[i] });

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Models/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Models.Find(id);
            //db.Models.Remove(model);
            model.Deleted = true;
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
