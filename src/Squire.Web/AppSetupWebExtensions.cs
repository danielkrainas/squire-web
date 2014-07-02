namespace Squire.Web
{
    using Microsoft.Practices.ServiceLocation;
    using Squire.Setup;
    using Squire.Web.Http;
    using Squire.Web.Mvc;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class AppSetupWebExtensions
    {
        public static IAppSetup<HttpApplication> UseContainerControllerFactory(this IAppSetup<HttpApplication> setup, IServiceLocator locator)
        {
            return setup.UseContainerControllerFactory(ControllerBuilder.Current, locator);
        }

        public static IAppSetup<HttpApplication> UseContainerControllerFactory(this IAppSetup<HttpApplication> setup, ControllerBuilder builder, IServiceLocator locator)
        {
            builder.SetControllerFactory(new IocControllerFactory(locator));
            return setup;
        }

        public static IAppSetup<HttpApplication> UseContainerHttpControllerActivator(this IAppSetup<HttpApplication> setup, IServiceLocator locator)
        {
            return setup.UseContainerHttpControllerActivator(GlobalConfiguration.Configuration.Services, locator);
        }

        public static IAppSetup<HttpApplication> UseContainerHttpControllerActivator(this IAppSetup<HttpApplication> setup, ServicesContainer services, IServiceLocator locator)
        {
            services.UseContainerActivator(locator);
            return setup;
        }

        public static IAdvancedAppSetup<HttpApplication, RouteCollection> ForRoutes(this IAppSetup<HttpApplication> setup)
        {
            return setup.ForRoutes(RouteTable.Routes);
        }

        public static IAdvancedAppSetup<HttpApplication, RouteCollection> ForRoutes(this IAppSetup<HttpApplication> setup, RouteCollection routes)
        {
            return new AdvancedAppSetup<HttpApplication, RouteCollection>(setup, routes);
        }

        public static IAdvancedAppSetup<HttpApplication, RouteCollection> MapHome(this IAdvancedAppSetup<HttpApplication, RouteCollection> setup, string url, string controller = "Home", string action = "Index", string[] namespaces = null)
        {
            setup.Advanced.MapHome(url, controller, action, namespaces);
            return setup;
        }
    }
}
