using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeApps.Infrastructure
{
    public class PageViewLoggingAttribute : ActionFilterAttribute
    {
        private static readonly TimeSpan pageViewDumpToDatabaseTimeSpan = new TimeSpan(0, 0, 10);
        private HomeAppsEntities db = new HomeAppsEntities();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logging myLogging = new Logging();

            myLogging.ControllerName = filterContext
                .ActionDescriptor
                .ControllerDescriptor
                .ControllerName;
            myLogging.ActionName = filterContext.ActionDescriptor.ActionName;
            myLogging.Date = TimeZoneInfo.ConvertTime(
                filterContext.HttpContext.Timestamp,
                TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
            );
            myLogging.IPAddress = filterContext.HttpContext.Request.UserHostAddress;
            myLogging.ActionParameters = "";

            myLogging.AbsoluteUri = filterContext.HttpContext.Request.UrlReferrer?.AbsoluteUri;

            foreach (var pram in filterContext.ActionParameters)
            {
                myLogging.ActionParameters += pram + " ";
            }

            myLogging.ActionParameters = myLogging.ActionParameters.Trim();

            db.Loggings.Add(myLogging);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return;
            }

            if (
                myLogging.IPAddress.Trim().StartsWith("14.202")
                || myLogging.IPAddress.Trim().StartsWith("18.216")
                || myLogging.IPAddress.Trim().StartsWith("37.252")
                || myLogging.IPAddress.Trim().StartsWith("52.34")
                || myLogging.IPAddress.Trim().StartsWith("54.67")
                || myLogging.IPAddress.Trim().StartsWith("54.186")
                || myLogging.IPAddress.Trim().StartsWith("54.213")
                || myLogging.IPAddress.Trim().StartsWith("66.249")
                || myLogging.IPAddress.Trim().StartsWith("67.227")
                || myLogging.IPAddress.Trim().StartsWith("77.88")
                || myLogging.IPAddress.Trim().StartsWith("93.158")
                || myLogging.IPAddress.Trim().StartsWith("94.23")
                || myLogging.IPAddress.Trim().StartsWith("103.196.137")
                || myLogging.IPAddress.Trim().StartsWith("129.78.110")
                || myLogging.IPAddress.Trim().StartsWith("141.8")
                || myLogging.IPAddress.Trim().StartsWith("157.55")
                || myLogging.IPAddress.Trim().StartsWith("179.178")
                || myLogging.IPAddress.Trim().StartsWith("187.189.160")
                || myLogging.IPAddress.Trim().StartsWith("188.165") == true
            )
            {
                filterContext.Result = new RedirectResult("http://www.kink.com");
                return;
            }
        }
    }
}
