using HomeApps.Infrastructure;
using HomeApps.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    [Access]
    public class MilesController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: Miles
        public ActionResult Index(int id)
        {   
            MilesViewModel Miles = new MilesViewModel();

            var tempmils = db.Miles.OrderBy(m => m.GasDate).Where(m => m.AutoID == id).ToList();//.Include(m => m.Station).Include(m => m.Auto).ToList();
            Miles.AutoName = db.Autos.Where(s => s.AutoID == id).FirstOrDefault()?.AutoName;

            foreach (Mile item in tempmils)
            {

                MilesModel test = new MilesModel();

                DuckCopyShallow(test, item);
                

                Miles.Miles.Add(test);

            }

            if (Miles.Miles.Count().Equals(0))
            {
                return View(Miles);
            }

            decimal LastMiles = 0;
            foreach (MilesModel item in Miles.Miles)
            {
                if (LastMiles.Equals(0))
                {
                    LastMiles = item.TotalMilesDriven;
                }
                else
                {
                    item.MilesDrove = item.TotalMilesDriven - LastMiles;
                    item.MPG =  Convert.ToInt32(item.MilesDrove / item.TotalGallons);
                    LastMiles = item.TotalMilesDriven;

                }
            }



            Miles.MPG = 0;
            Miles.LastMiles = 0;
            
            Miles.MaxMiles = Miles.Miles.Max(m => m.TotalMilesDriven);
            Miles.MinMiles = Miles.Miles.Min(m => m.TotalMilesDriven);
            Miles.TotalGallons = Miles.Miles.Sum(m => m.TotalGallons);
            
            Miles.TotalMiles = Miles.MaxMiles - Miles.MinMiles;
            
            Miles.Date30 = DateTime.Now.AddDays(-30);

            if(Miles.Miles.Where(m => m.GasDate >= Miles.Date30).Count().Equals(0))
            {
                return View(Miles);
            }

            Miles.Day30MaxMiles = Miles.Miles.Where(m => m.GasDate >= Miles.Date30).Max(m => m.TotalMilesDriven);
            Miles.Day30MaxMinMiles = Miles.Miles.Where(m => m.GasDate >= Miles.Date30).Min(m => m.TotalMilesDriven);
            Miles.Day30MaxTotalGallons = Miles.Miles.Where(m => m.GasDate >= Miles.Date30).Sum(m => m.TotalGallons);
            
            Miles.Day30MaxTotalMiles = Miles.Day30MaxMiles - Miles.Day30MaxMinMiles;

            Miles.TotalMPG = Miles.TotalMiles / Miles.TotalGallons;

            Miles.Day30TotalMPG = Miles.Day30MaxTotalMiles / Miles.Day30MaxTotalGallons;

            return View(Miles);
        }

        // GET: Miles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mile mile = db.Miles.Find(id);
            if (mile == null)
            {
                return HttpNotFound();
            }
            return View(mile);
        }


        public void DuckCopyShallow<T1, T2>(T1 dst, T2 src)
        {
            var srcT = src.GetType();
            var dstT = dst.GetType();
            foreach (var f in srcT.GetFields())
            {
                var dstF = dstT.GetField(f.Name);
                if (dstF == null)
                    continue;
                dstF.SetValue(dst, f.GetValue(src));
            }

            foreach (var f in srcT.GetProperties())
            {
                try
                {
                    var dstF = dstT.GetProperty(f.Name);
                    if (dstF == null)
                        continue;

                    dstF.SetValue(dst, f.GetValue(src, null), null);
                }
                ///Really need to write this error out.
                catch (Exception ex) {
                    var errormessage = ex.Message;
                }
                
            }

            //return dst;
        }


        // GET: Miles/Create
        public ActionResult Create(int id)
        {

            ViewBag.StationID = new SelectList(db.Stations.Where(m => m.Deleted == false).AsEnumerable(), "StationID", "Name").Append(new SelectListItem() { Text = "Select Station", Selected = true, Value = "0" });

            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID");

            ViewBag.GasTypeID = new SelectList(items: db.Types.Where(m => m.Deleted == false).AsEnumerable(), "GasTypeID", "TypeName").Append(new SelectListItem() { Text = "Select Gas Type", Selected = true, Value = "0" });

            return View(new Models.MilesAddModel() { AutoID = id });
        }

        // POST: Miles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.MilesAddModel mile)
        {
            if (ModelState.IsValid)
            {
                Mile tempmile = new Mile();
                foreach (PropertyInfo property in mile.GetType().GetProperties())
                {
                    if (!property.CanRead || (property.GetIndexParameters().Length > 0))
                        continue;

                    PropertyInfo propertyinfo = tempmile.GetType().GetProperty(property.Name);
                    if ((propertyinfo != null) && (propertyinfo.CanWrite))
                        propertyinfo.SetValue(tempmile, property.GetValue(mile, null), null);
                }

                tempmile.CreateModifyLog = CreateModLog();
                //tempmile.Station = db.Stations.Where(m => m.StationID == tempmile.StationID).First();
                db.Miles.Add(tempmile);
                db.SaveChanges();
                return RedirectToAction("Index",new { id = tempmile.AutoID});
            }

           


            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Name", mile.StationID).Append(new SelectListItem() { Text = "Select Station", Value = "0" });
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", mile.ModfiyID);
            ViewBag.GasTypeID = new SelectList(db.CreateModifyLogs, "GasTypeID", "TypeName", mile.GasTypeID).Append(new SelectListItem() { Text = "Select Gas Type", Value = "0" }); ;
            
            return View(mile);
        }

        // GET: Miles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mile mile = db.Miles.Find(id);
            if (mile == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Name", mile.StationID);
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", mile.ModfiyID);
            ViewBag.GasTypeID = new SelectList(db.CreateModifyLogs, "GasTypeID", "TypeName", mile.GasTypeID);
            return View(mile);
        }

        // POST: Miles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mile mile)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(mile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Miles", new { id = mile.AutoID });
                
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Name", mile.StationID).Append(new SelectListItem() { Text = "Select Station", Selected = true, Value = "0" });
            ViewBag.ModfiyID = new SelectList(db.CreateModifyLogs, "CreateModifyID", "CreateModifyID", mile.ModfiyID);
            return RedirectToAction("Index");
        }

        // GET: Miles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mile mile = db.Miles.Find(id);
            if (mile == null)
            {
                return HttpNotFound();
            }
            return View(mile);
        }

        // POST: Miles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mile mile = db.Miles.Find(id);
            db.Miles.Remove(mile);
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


        protected CreateModifyLog CreateModLog()
        {  
            User user = ((User)this.Session["_CurrentUser"]);
         
            CreateModifyLog cml = new CreateModifyLog();
            cml.CreatedBy = user.UserID;
            cml.CreatedOn = DateTime.Now;

            db.CreateModifyLogs.Add(cml);
            db.SaveChanges();
           return cml;
        }

    }
}
