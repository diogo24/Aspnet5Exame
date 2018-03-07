using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Chapter15_UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            // example 1
            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);

            // example 2
            //routes.MapRoute("MyRoute", "{controller}/{action}");

            // example 3
            //routes.MapRoute("MyRoute", "{controller}/{action}", defaults: new { action = "index" });

            // example 4
            routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" });
        }
    }
}
