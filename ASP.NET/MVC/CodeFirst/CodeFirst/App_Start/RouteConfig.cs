using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static System.Collections.Specialized.BitVector32;

namespace CodeFirst
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomeData", action = "Index", id = UrlParameter.Optional }
                          
                

            );

            routes.MapRoute(
                name: "Shop",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Shop", action = "Index", id = UrlParameter.Optional }



            );

            routes.MapRoute(
               name: "Cart",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }



           );
          
            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }

           );

            routes.MapRoute(
                   name: "Register",
                   url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }



               );

        }

    }  
    
}
