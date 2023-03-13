using HomeApps.Infrastructure;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeApps
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //GlobalFilters.Filters.Add(new MyExceptionHandler());
            RegisterGlobalFilters(GlobalFilters.Filters);

            Bootstrapper.Initialise();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new PageViewLoggingAttribute());
        }
    }
}