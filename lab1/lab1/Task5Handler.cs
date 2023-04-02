using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1 {
    public class Task5Handler : IHttpHandler {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context) {
            if(context.Request.HttpMethod == "GET") {
                context.Response.WriteFile("./Static/task5.html");
            }else if(context.Request.HttpMethod == "POST") {
                HttpRequest request = context.Request;
                string X = request.Form["X"];
                string Y = request.Form["Y"];
                context.Response.Write(Double.Parse(X) * Double.Parse(Y));
            }
        }
    }
}