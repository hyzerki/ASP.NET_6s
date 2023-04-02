using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1 {
    public class Task4Handler : IHttpHandler {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context) {
            HttpRequest request = context.Request;
            string X = request.Form["X"];
            string Y = request.Form["Y"];
            context.Response.Write(Double.Parse(X) + Double.Parse(Y));
        }
    }
}