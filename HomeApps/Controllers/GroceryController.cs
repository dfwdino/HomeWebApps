using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    public class GroceryController : Controller
    {

        private HomeAppsEntities db = new HomeAppsEntities();

        public ActionResult Index()
        {
            return View(db.Lists.Where(m => m.GotItem == false));
        }
    }
}