using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Assignment
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "OrderDescending",
                routeTemplate: "api/{controller}/{action}/order",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "ActiveCampaigns",
               routeTemplate: "api/{controller}/{action}/active",
               defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "ClosedCampaigns",
               routeTemplate: "api/{controller}/{action}/closed",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
