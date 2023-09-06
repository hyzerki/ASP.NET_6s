using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    [RoutePrefix("AR")]
    public class AResearchController : Controller
    {

        [Route("AA")]
        [lab5b.Filters.ActionFilter]
        public void AA()
        {
            Response.Write("Controller Out\n");
        }
        [Route("AR")]
        [lab5b.Filters.ResultFilter]
        public void AR()
        {
            Response.Write("Controller Out\n");
        }
        [Route("AE")]
        [lab5b.Filters.ExceptionFilter]
        public void AE()
        {
            Response.Write("Controller Out\n");
            throw new Exception("Exception filter");
        }
    }
}