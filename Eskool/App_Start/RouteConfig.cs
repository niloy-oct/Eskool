using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eskool
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
         
            var namespaces = new[] { "Eskool.Controllers" };

            // Register the route with the namespaces
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: namespaces
            );
        }
    }
}
