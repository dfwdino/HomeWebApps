using System;
using System.Web;
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
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            
        }

    }
}
