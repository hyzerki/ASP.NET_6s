using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace lab1 {
    public class Task1Handler : IHttpHandler {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context) {
            HttpRequest request = context.Request;
            string a = request.QueryString["ParmA"];
            string b = request.QueryString["ParmB"];
            context.Response.Write($"GET-Http-MNS:ParmA = {a},ParmB = {b}");
        }
    }
}