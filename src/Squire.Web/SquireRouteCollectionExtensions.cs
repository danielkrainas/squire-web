namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class SquireRouteCollectionExtensions
    {
        public static void MapHome(this RouteCollection routes, string url = "", string controller = "Home", string action = "Index",  string[] namespaces = null)
        {
            routes.MapRoute(
                name: CommonRoutes.Home,
                url: url,
                namespaces: namespaces,
                defaults: new { controller = controller, action = action });
        }
    }
}
