using System;
using System.Web.Mvc;

namespace HomeApps
{
    public class MyExceptionHandler : ActionFilterAttribute, IExceptionFilter

    {

        public void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;

            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult()
            {

                ViewName = "SomeException"

            };

        }

    }
}