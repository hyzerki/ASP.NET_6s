using System.Web.Mvc;
using System.Web.Routing;

namespace lab5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"CResearch",
                url: "CResearch/{action}",
                defaults: new { controller = "CResearch", action = "C01"},
                constraints: new { httpMethod = new HttpMethodConstraint("GET", "POST") }
            );

            routes.MapRoute(
                name: "MResearchRoute3",    
                url: "V3/{controller}/{X}/{action}/",
                defaults: new { controller = "MResearch", action = "M03", X = UrlParameter.Optional },
                constraints: new { X = "^X$|^$" }
            );

            routes.MapRoute(
                name: "MResearchRoute2",
                url: "V2/{controller}/{action}/",
                defaults: new { controller = "MResearch", action = "M02"  }
            );

            routes.MapRoute(
                name: "MResearchRoute1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional },
                constraints: new { action = "^M02$|^M01$" }
            );

            routes.MapRoute(
                name: "NotFoundPath",
                url:"{*url}",
                defaults: new { controller = "MResearch", action = "MXX" }
                );
        }
    }
}
