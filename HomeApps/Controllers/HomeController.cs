using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(HomeApps.User user)
        {

            HomeAppsEntities homeAppsEntities = new HomeAppsEntities();

            int foundUser = homeAppsEntities.Users.Where(m => m.UserName == user.UserName && m.Password == user.Password).ToList().Count();

            if (foundUser.Equals(0))
            {
                ModelState.AddModelError("UserName", "User is not found with type of info.");
                return View(user);
            }

            return RedirectToAction("AppList");
        }


        public ActionResult AppList()
        {
            return View();
        }



    }
}
