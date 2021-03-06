﻿namespace Squire.Web.Http
{
    using Microsoft.Practices.ServiceLocation;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    public static class ServiceContainerExtensions
    {
        public static void UseContainerActivator(this ServicesContainer services, IServiceLocator locator)
        {
            services.Replace(typeof(IHttpControllerActivator), new IocHttpControllerActivator(locator));
        }
    }
}
