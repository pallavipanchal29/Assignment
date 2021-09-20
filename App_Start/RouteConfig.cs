using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Assignment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/",
               defaults: new { controller = "Campaign", action = "Index"}
           );

            routes.MapRoute(
              name: "Ordered Campaigns",
              url: "{controller}/{action}/",
              defaults: new { controller = "Campaign", action = "order" }
          );

            routes.MapRoute(
             name: "Active Campaigns",
             url: "{controller}/{action}/",
             defaults: new { controller = "Campaign", action = "active" }
         );
            routes.MapRoute(
             name: "Closed Campaigns",
             url: "{controller}/{action}/",
             defaults: new { controller = "Campaign", action = "closed" }
         );
        }
    }
}
