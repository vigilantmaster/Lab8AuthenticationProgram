﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Lab8AuthenticationProgram
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
