using HomeApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HomeApps.Controllers
{
    //public interface IHelloer
    //{
    //    string SayHello();
    //}

    //[DisplayName("Title")]
    //public class HelloerA : IHelloer
    //{
    //    public string SayHello()
    //    {
    //        return $"Hello from {nameof(HelloerA)}";
    //    }
    //}


    public class AdminController : Controller
    {
        private readonly HomeAppsEntities _db;

        //public IHelloer Hello { get; set; }


        //public AdminController(IHelloer hello)
        public AdminController()
        {

            //Hello = hello;
            //var test = Hello.SayHello();
            //System.Diagnostics.Debug.WriteLine(test);
       
        }


        // GET: Admin
        public ActionResult Index()
        {

            UserViewModel userViewModel = new UserViewModel();

            HomeAppsEntities db = new HomeAppsEntities();

            List<UserViewModel> allusers = new List<UserViewModel>();

            allusers = db.Users.Where(m => m.FirstName != "System").ToList().Select(m => new UserViewModel
            {
                FirstName = m.FirstName,
                IsAdmin = m.Role.RoleName.Equals("Admin"),
                UsersSchema = Infrastructure.Helper.GetUsersSchemasName(m, db.Schemas)

            }).ToList();
      
        return View(allusers);
        }

        public ActionResult Schemas()
        {
            List<Schema> schema = _db.Schemas.Include(m => m.UserSchema).Include(m => m.UserSchema.User).ToList();

            return View(schema);
        }

        private List<string> GetAllControllers()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = asm.GetTypes()
        .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
        .Select(x => new { Controller = x.DeclaringType.Name })
        .GroupBy(m => m.Controller)
        .Select(m => m.Key)
        .ToList();

            return controlleractionlist;
        }

        public ActionResult AddSchema()
        {
            return View(GetAllControllers());
        }

        [HttpPost]
        public ActionResult AddSchema(Schema schema)
        {
            return View();
        }


    }
}