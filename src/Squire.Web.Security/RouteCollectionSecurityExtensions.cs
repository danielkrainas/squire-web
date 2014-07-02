namespace Squire.Web.Security
{
    using Squire.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteCollectionSecurityExtensions
    {
        public static void MapAccountRoutes(this RouteCollection routes, string controllerName = "Account", string controllerUrlPath = "account/", string[] namespaces = null, bool registration = true)
        {
            controllerName.VerifyParam("controllerName").IsNotNull();
            controllerUrlPath.VerifyParam("controllerUrlPath").IsNotNull();
            routes.MapRoute(
                name: AccountRoutes.Login,
                url: controllerUrlPath + "login",
                namespaces: namespaces,
                defaults: new { controller = controllerName, action = "Login" });

            routes.MapRoute(
                name: AccountRoutes.Logout,
                url: controllerUrlPath + "logout",
                namespaces: namespaces,
                defaults: new { controller = controllerName, action = "Logout" });

            routes.MapRoute(
                name: AccountRoutes.Profile,
                url: controllerUrlPath,
                namespaces: namespaces,
                defaults: new { controller = controllerName, action = "Index" });

            if (registration)
            {
                routes.MapRoute(
                    name: AccountRoutes.Registration,
                    url: controllerUrlPath + "register",
                    namespaces: namespaces,
                    defaults: new { controller = controllerName, action = "Register" });
            }
        }
    }
}
