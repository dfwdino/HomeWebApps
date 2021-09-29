using HomeApps.Models;
using System.Linq;
using System.Web.Mvc;
using HomeApps.Infrastructure;
using System;

namespace HomeApps.Controllers
{
    
    public class HomeController : Controller
    {

        HomeAppsEntities db;

        public ActionResult Index() => Session["_CurrentUser"] == null ? View() : (ActionResult)RedirectToAction("AppList");

        public ActionResult Login()
        {

            return View();
        }

       
        public HomeController()
        {
            db = new HomeAppsEntities();
        }

        

        [HttpPost]
        public ActionResult Login(User user)
        {
            User foundUser = db.Users.Where(m => m.UserName == user.UserName && m.Password == user.Password).FirstOrDefault();

            if (foundUser == null)
            {
                ModelState.AddModelError("UserName", "User is not found with type of info.");
                return View(foundUser);
            }

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.IsAdmin = foundUser.Role.RoleName.Equals("Admin");
            userViewModel.UsersSchema = Helper.GetUsersSchemasName(foundUser, db.Schemas);

            Helper.DuckCopyShallow(userViewModel, foundUser);


            this.Session["_CurrentUser"] = userViewModel;

            return RedirectToAction("AppList");
        }

        


        public ActionResult AppList()
        {
            return View();
        }



    }
}
