using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Filters
{
    public class ActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("ActionFilter:Вызов перед вызовом метода действия\n");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("ActionFilter:Вызов после работы метода действия\n");
        }
    }
}