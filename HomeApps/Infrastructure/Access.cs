using HomeApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeApps.Infrastructure
{
    public class AccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var session = HttpContext.Current.Session;

            session["url"] = HttpContext.Current.Request.Url.ToString();

            if (session["_CurrentUser"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Login",
                    area = "Login"
                }));
            }
            else
            {
                
                UserViewModel currentuser = session["_CurrentUser"] as UserViewModel;

                var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();

                if (currentuser.UsersSchema.Contains(controller).Equals(false) && !currentuser.IsAdmin)
                {
                    throw new Exception("Dont have access to this page.");
                }


            }

        }

        public static HttpRequest GetHttpRequest()
        {
            return HttpContext.Current.Request;
        }
    }
}