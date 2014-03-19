using System.Web.Mvc;
using System.Web.Routing;

namespace CalorieTracker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}/{message}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional, message = UrlParameter.Optional}
                );
        }
    }
}