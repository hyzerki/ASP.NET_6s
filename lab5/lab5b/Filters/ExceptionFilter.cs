using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(!filterContext.ExceptionHandled)
            {
                filterContext.HttpContext.Response.Write($"{filterContext.Exception.Message}\n"); 
                filterContext.ExceptionHandled = true;
            }
        }
    }
}