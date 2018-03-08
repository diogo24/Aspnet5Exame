using Chapter15_UrlsAndRoutes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Chapter15_UrlsAndRoutes
{
    public class RouteConfig
    {
        #region Chapter 14

        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    //routes.MapRoute(
        //    //    name: "Default",
        //    //    url: "{controller}/{action}/{id}",
        //    //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    //);

        //    // example 1
        //    //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
        //    //routes.Add("MyRoute", myRoute);

        //    // example 2
        //    //routes.MapRoute("MyRoute", "{controller}/{action}");

        //    // example 3
        //    //routes.MapRoute("MyRoute", "{controller}/{action}", defaults: new { action = "index" });

        //    ////Example 8
        //    //routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "Home", action = "Index" });

        //    //// Example 7
        //    //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });

        //    //// Example 6
        //    //routes.MapRoute("", "X{controller}/{action}");

        //    //// example 4
        //    //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" });

        //    //// example 5
        //    //routes.MapRoute("", "Public/{controller}/{action}", new { controller = "Home", action = "Index" });

        //    //// Example 9
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
        //    // new
        //    // {
        //    //     controller = "Home",
        //    //     action     = "Index",
        //    //     id         = "DefaultId"
        //    // });

        //    //// Example 10
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
        //    // new
        //    // {
        //    //     controller = "Home",
        //    //     action     = "Index",
        //    //     id         = UrlParameter.Optional
        //    // });

        //    //// Example 11
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    // new
        //    // {
        //    //     controller = "Home",
        //    //     action     = "Index",
        //    //     id         = UrlParameter.Optional
        //    // });

        //    //// Example 12
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    // new
        //    // {
        //    //     controller = "Home",
        //    //     action     = "Index",
        //    //     id         = UrlParameter.Optional
        //    // },
        //    // new[] { "Chapter15_UrlsAndRoutes.AdditionalControllers" });

        //    //// Example 13
        //    //routes.MapRoute("AddControllerRoute", "Home/{action}/{id}/{*catchall}",
        //    //    new
        //    //    {
        //    //        controller = "Home",
        //    //        action     = "Index",
        //    //        id         = UrlParameter.Optional
        //    //    },
        //    //    new[] { "Chapter15_UrlsAndRoutes.AdditionalControllers" });

        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    //    new
        //    //    {
        //    //        controller = "Home",
        //    //        action     = "Index",
        //    //        id         = UrlParameter.Optional
        //    //    },
        //    //    new[] { "Chapter15_UrlsAndRoutes.Controllers" });

        //    //// Example 14
        //    //Route myRoute = routes.MapRoute("AddContollerRoute",
        //    //    "Home/{action}/{id}/{*catchall}",
        //    //    new
        //    //    {
        //    //        controller = "Home",
        //    //        action     = "Index",
        //    //        id         = UrlParameter.Optional
        //    //    },
        //    //    new[] { "Chapter15_UrlsAndRoutes.AdditionalControllers" });
        //    //myRoute.DataTokens["UseNamespaceFallback"] = false;

        //    //// Example 15
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        //    //    new { controller = "^H.*" },
        //    //    new[] { "Chapter15_UrlsAndRoutes.Controllers" });

        //    //// Example 16
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        //    //    new { controller = "^H.*", action = "^Index$|^About$" },
        //    //    new[] { "Chapter15_UrlsAndRoutes.Controllers" });

        //    //// Example 17
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        //    //    new { controller = "^H.*", action = "Index|About",
        //    //        httpMethod = new HttpMethodConstraint("GET")},
        //    //    new[] { "Chapter15_UrlsAndRoutes.Controllers" });

        //    //// Example 18
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        //    //    new
        //    //    {
        //    //        controller = "^H.*",
        //    //        action = "Index|About",
        //    //        httpMethod = new HttpMethodConstraint("GET"),
        //    //        id = new RangeRouteConstraint(10, 20)
        //    //    },
        //    //    new[] { "Chapter15_UrlsAndRoutes.Controllers" });

        //    //// Example 20
        //    //routes.MapRoute("FirefoxRoute", "{*catchall}",
        //    //     new { controller = "Home", action = "Index" },
        //    //     new { customConstraint = new UserAgentConstraint("Firefox") },
        //    //     new[] { "Chapter15_UrlsAndRoutes.AdditionalControllers" }
        //    //    );

        //    //// Example 19
        //    //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
        //    //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        //    //    new
        //    //    {
        //    //        controller = "^H.*",
        //    //        httpMethod = new HttpMethodConstraint("GET"),
        //    //        id         = new CompoundRouteConstraint(new IRouteConstraint[] {
        //    //            new AlphaRouteConstraint(),
        //    //            new MinLengthRouteConstraint(6)
        //    //        })
        //    //    },
        //    //    new[] { "Chapter15_UrlsAndRoutes.Controllers" });

        //    // Example 21
        //    routes.MapMvcAttributeRoutes();

        //    routes.MapRoute("Default", "{controller}/{action}/{id}",
        //        new
        //        {
        //            controller = "Home",
        //            action     = "Index",
        //            id         = UrlParameter.Optional
        //        },
        //        new[] { "Chapter15_UrlsAndRoutes.Controllers" });
        //}

        #endregion

        #region Chapter 15

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            new
            {
                controller = "Home",
                action     = "Index",
                id         = UrlParameter.Optional
            });
        }

        #endregion 
    }
}
