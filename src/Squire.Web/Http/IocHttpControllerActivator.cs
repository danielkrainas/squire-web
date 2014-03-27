namespace Squire.Web.Http
{
    using Squire.Validation;
    using Microsoft.Practices.ServiceLocation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    public class IocHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IServiceLocator locator;

        public IocHttpControllerActivator(IServiceLocator locator)
        {
            locator.VerifyParam("locator").IsNotNull();
            this.locator = locator;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            try
            {
                return this.locator.GetService(controllerType) as IHttpController;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
