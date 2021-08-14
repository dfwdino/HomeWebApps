using HomeApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
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

            var viewforadming = db.Users;

            return View(viewforadming);
        }

        public ActionResult Schemas()
        {
            List<Schema> schema = _db.Schemas.Include(m => m.UserSchema).Include(m => m.UserSchema.User).ToList();

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