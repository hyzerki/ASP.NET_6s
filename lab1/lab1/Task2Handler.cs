using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1 {
    public class Task2Handler : IHttpHandler {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context) {
            HttpRequest request = context.Request;
            string a = request.Form["ParmA"];
            string b = request.Form["ParmB"];
            context.Response.Write($"{context.Request.HttpMethod}-Http-MNS:ParmA = {a},ParmB = {b}");
        }
    }
}