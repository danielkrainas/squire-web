namespace Squire.Web.Security
{
    using Squire.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteCollectionExtensions
    {
        public static void MapHomeRoute(this RouteCollection routes)
        {
            routes.MapRoute(
                name: CommonRoutes.Home,
                url: "",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}
