using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mod02_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "OperaTitleRoute",
              url: "opera/title/{title}",
              defaults: new { controller = "opera", action = "DetailsByTitle", title = UrlParameter.Optional }
              //可以用regexp限定title的pattern
              //但是網址的rewrite不可以用regexp
              constraints: new { title=@"[A-Z]/d{9}"}
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Opera", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
