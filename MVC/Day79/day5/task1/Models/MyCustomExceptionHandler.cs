using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace task1.Models
{
    public class MyCustomExceptionHandler:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };

            base.OnException(filterContext);
        }
    }
}
