using HomeApps.Infrastructure;
using HomeApps.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    [Access]
    public class AdminController : Controller
    {
        private readonly HomeAppsEntities _db = new HomeAppsEntities();

        public AdminController()
        {
        }

        // GET: Admin
        public ActionResult Index()
        {
            UserViewModel userViewModel = new UserViewModel();

            List<UserViewModel> allusers = new List<UserViewModel>();

            allusers = _db.Users.Where(m => m.FirstName != "System").ToList().Select(m => new UserViewModel
            {
                FirstName = m.FirstName,
                IsAdmin = m.Role.RoleName.Equals("Admin"),
                UsersSchema = Infrastructure.Helper.GetUsersSchemasName(m, _db.Schemas)
            }).ToList();

            return View(allusers);
        }

        public ActionResult Schemas()
        {
            List<Schema> schema = _db.Schemas.Include(m => m.UserSchema).Include(m => m.UserSchema.User).ToList();

            return View(schema);
        }

        private dynamic GetAllControllers()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = asm.GetTypes()
                .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                .Select(x => new { Controller = x.DeclaringType.Name })
                .GroupBy(m => m.Controller)
                .Select(m => new { Schema = m.Key.Replace("Controller", "") })
                .ToList();

            return controlleractionlist;
        }

        public ActionResult AddSchema()
        {
            ViewBag.Schema = new SelectList(GetAllControllers(), "Schema", "Schema");
            ViewBag.People = new SelectList(_db.Users.OrderBy(m => m.FirstName), "UserID", "FirstName");

            return View();
        }

        [HttpPost]
        public ActionResult AddSchema([Bind(Include = "Schema,UserID")] int UserID, string Schema)
        {
            Schema FoundSchema = _db.Schemas.FirstOrDefault(m => m.SchemaName == Schema);
            UserSchema FoundUserSchema = _db.UserSchemas.FirstOrDefault(m => m.SchemaID == FoundSchema.SchemaID);

            if (FoundSchema != null && FoundUserSchema != null)
            {
                UserViewModel currentuser = (UserViewModel)this.Session["_CurrentUser"];

                _db.UserSchemas.Add(new UserSchema { SchemaID = FoundSchema.SchemaID, UsersID = UserID, ModfiyID = currentuser.UserID });
            }

            User user = ((User)this.Session["_CurrentUser"]);

            return RedirectToAction("Index");
        }
    }
}