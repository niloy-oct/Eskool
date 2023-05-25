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
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //    name: "PrescriptionShareDetailsData_ForGrid",
        //    url: "{Reports}/{PrescriptionShareDetailsData_ForGrid}/{draw}/{start}/{length}",
        //    defaults: new { controller = "PrescriptionShareDetailsData_ForGrid", action = "Reports" }
        //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "OTP", id = UrlParameter.Optional }
            );
        }
    }
}
