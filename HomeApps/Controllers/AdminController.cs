using HomeApps.Infrastructure;
using HomeApps.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
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

        public ActionResult AllUsers()
        {
            List<User> allusers = _db.Users.ToList();

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
            Schema FoundSchema = _db.Schemas.ToList().Where(m => m.SchemaName.Contains(Schema)).FirstOrDefault();
            
            User user = ((User)this.Session["_CurrentUser"]);

            if (FoundSchema == null)
            {
                _db.Schemas.Add(new Schema { SchemaName = Schema, ModfiyID = user.UserID });
                _db.SaveChanges();

                FoundSchema = _db.Schemas.ToList().Where(m => m.SchemaName.Contains(Schema)).FirstOrDefault();
            }

            UserSchema FoundUserSchema = _db.UserSchemas.FirstOrDefault(m => m.SchemaID == FoundSchema.SchemaID);

            if (FoundSchema != null && FoundUserSchema == null)
            {
                UserViewModel currentuser = (UserViewModel)this.Session["_CurrentUser"];

                _db.UserSchemas.Add(new UserSchema { SchemaID = FoundSchema.SchemaID, UsersID = UserID, ModfiyID = currentuser.UserID, Deleted = false });
                _db.SaveChanges();
            }

            

            return RedirectToAction("Index");
        }
    }
}