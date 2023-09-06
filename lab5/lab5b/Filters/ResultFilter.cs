using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Filters
{
    public class ResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("ResultFilter:Вызов перед получением результата действия\n");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("ResultFilter:Вызов после получения результата действия\n");
        }
    }
}