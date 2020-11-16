using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
  
    public class AdminController : Controller
    {
        private HomeAppsEntities db = new HomeAppsEntities();

        // GET: Admin
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult Schemas()
        {
            List<Schema> schema = db.Schemas.Include(m => m.UserSchema).Include(m => m.UserSchema.User).ToList();

            return View(schema);
        }

        public ActionResult AddSchema()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSchema(Schema schema)
        {
            return View();
        }


    }
}