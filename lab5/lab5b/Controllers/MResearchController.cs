using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        [Route("{f:float}/{str:length(2, 5)}")]
        [AcceptVerbs("GET", "DELETE")]
        public ActionResult M03(float f, string str)
        {
            return Content($"{Request.HttpMethod}:M03/{f}/{str}");
        }

        [Route("{n:int}/{str}")]
        [HttpGet]
        public ActionResult M01(int n, string str)
        {
            return Content($"GET:M01/{n}/{str}");
        }

        [Route("{b:bool}/{letters:alpha}")]
        [AcceptVerbs("GET", "POST")]
        public ActionResult M02(bool b, string letters)
        {
            return Content($"{Request.HttpMethod}:M02/{b}/{letters}");
        }

        [Route("{str:length(3, 4)}/{num:range(100, 200)}")]
        [HttpPut]
        public ActionResult M04(string str, int num)
        {
            return Content($"{Request.HttpMethod}:M04/{str}/{num}");
        }

        [Route("{mail:regex(^\\w+@\\w+\\.\\w+$)}")]
        [HttpPost]
        public ActionResult M05(string mail)
        {
            return Content($"{Request.HttpMethod}:M05/{mail}");
        }
    }
}