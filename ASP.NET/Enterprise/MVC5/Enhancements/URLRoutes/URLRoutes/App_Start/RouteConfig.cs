using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;
using URLRoutes.Infrastructure;
namespace URLRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "Home", action = "Index"  });
            
            //routes.MapRoute("ShopSchema", "Shop/{action}", new  { controller = "Home" });
            //routes.MapRoute("MyRouteX", "X{controller}/{action}");

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "URLRoutes.Controllers" });

           
            // Route MyConstrainedRoute = routes.MapRoute("MyConstrainedRoute", "Home/{controller}/{action}/{id}", new { controller = "Home", action = "Index", id=UrlParameter.Optional }, new[] {"URLRoutes.AdditionalControllers"});

            // MyConstrainedRoute.DataTokens["UseNameSpaceFallBack"] = false;

             //routes.MapRoute("MyVariableRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new {  controller = "^H.*", action = "^Index$|^About$", httpMethod = new HttpMethodConstraint("GET")}, new[] { "URLRoutes.Controllers" });

             //routes.MapRoute("MyVariableRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new { controller = "^H.*", action = "Index|About", httpMethod = new HttpMethodConstraint("GET"), id = new RangeRouteConstraint(10, 20)}, new[] { "URLRoutes.Controllers" });


            //routes.MapRoute("ChromeRoute", "{*catchall}", new { controller = "Home", action = "Index" }, new { customConstraint = new UserAgentConstraint("Mozilla") }, new[] { "URLRoutes.AdditionalControllers" });



           // routes.MapRoute("MyVariableRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new { controller = "^H.*", action = "Index|About", httpMethod = new HttpMethodConstraint("GET"), id = new CompoundRouteConstraint(new IRouteConstraint[] { new AlphaRouteConstraint(), new MinLengthRouteConstraint(6) }) }, new[] { "URLRoutes.Controllers" });


              //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller= "Home",action = "Index"});

           
            //routes.MapRoute("FullRoute", "Public/{controller}/{action}", new { controller= "Home",action = "Index"});


        }
    }
}