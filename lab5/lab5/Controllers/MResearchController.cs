﻿using System.Web.Mvc;

namespace lab5.Controllers
{
    public class MResearchController : Controller
    {
        [HttpGet]
        public ActionResult M01()
        {
            return Content("GET:M01");
        }

        [HttpGet]
        public ActionResult M02()
        {
            return Content("GET:M02");
        }

        [HttpGet]
        public ActionResult M03()
        {
            return Content("GET:M03");
        }

        [HttpGet]
        public ActionResult MXX()
        {
            return Content("GET:MXX");
        }
    }
}