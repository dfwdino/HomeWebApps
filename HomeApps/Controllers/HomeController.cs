using HomeApps.Models;
using System.Linq;
using System.Web.Mvc;
using HomeApps.Infrastructure;
using System;

namespace HomeApps.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index() => Session["_CurrentUser"] == null ? View() : (ActionResult)RedirectToAction("AppList");

        public ActionResult Login()
        {

            return View();
        }

       
        public HomeController()
        {
         
        }



        [HttpPost]
        public ActionResult Login(HomeApps.User user)
        {
            HomeAppsEntities db = new HomeAppsEntities();

            User foundUser = db.Users.Where(m => m.UserName == user.UserName && m.Password == user.Password).FirstOrDefault();

            if (foundUser == null)
            {
                ModelState.AddModelError("UserName", "User is not found with type of info.");
                return View(foundUser);
            }



            UserViewModel userViewModel = new UserViewModel();
            userViewModel.IsAdmin = foundUser.Role.RoleName.Equals("Admin");
            userViewModel.Roles = string.Join(",",foundUser.UserSchemas.Select(m => m.Schema.SchemaName).ToArray());

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
