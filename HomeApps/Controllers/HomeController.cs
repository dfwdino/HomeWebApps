using System.Linq;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index() => Session["_CurrentUser"] == null ? View() : (ActionResult)RedirectToAction("AppList");

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(HomeApps.User user)
        {
            HomeAppsEntities db = new HomeAppsEntities();

        User foundUser = db.Users.Where(m => m.UserName == user.UserName && m.Password == user.Password).FirstOrDefault();
        
            if (foundUser == null)
            {
                ModelState.AddModelError("UserName", "User is not found with type of info.");
                return View(user);
            }
            else
            {
                this.Session["_CurrentUser"] = foundUser;
            }

            return RedirectToAction("AppList");
        }


        public ActionResult AppList()
        {
            return View();
        }



    }
}
