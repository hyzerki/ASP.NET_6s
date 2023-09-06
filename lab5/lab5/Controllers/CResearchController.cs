using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace lab5.Controllers
{
    public class CResearchController:Controller
    {
        [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
        public ActionResult C01()
        {
            return Content($"{Request.HttpMethod}<br>{Request.QueryString}<br>{Request.Url}<br>{Request.Headers}<br>{new StreamReader(Request.InputStream).ReadToEnd()}");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult C02()
        {
            return Content($"{Response.Status}<br>{Response.Headers}<br>{new StreamReader(Request.InputStream).ReadToEnd()}");
        }
    }
}