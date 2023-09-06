using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace lab5b.Controllers
{
    [RoutePrefix("CH")]
    public class CHResultController : Controller
    {
        // GET: CHResult
        static int x = 9;
        [Route("AD")]
        [HttpGet]
        [OutputCache(Duration = 20, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult AD()
        {
            x++;
            string t = DateTime.Now.ToLongTimeString();
            return Content($"GET:/AD:{t} \n {x}");
        }
        [Route("AP/{x}/{y}")]
        [HttpGet]
        [OutputCache(Duration = 20, VaryByParam = "x;y", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult AP(string x, string y)
        {
            string t = DateTime.Now.ToLongTimeString();
            return Content($"POST:/AP:{t}:{x}:{y}");
        }
    }
}