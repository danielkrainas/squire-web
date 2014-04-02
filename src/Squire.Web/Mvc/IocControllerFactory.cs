namespace Squire.Web.Mvc
{
    using Squire.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Microsoft.Practices.ServiceLocation;

    public class IocControllerFactory : DefaultControllerFactory
    {
        private IServiceLocator locator;

        public IocControllerFactory(IServiceLocator locator)
        {
            locator.VerifyParam("locator").IsNotNull();
            this.locator = locator;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                var service = this.locator.GetService(controllerType) as IController;
                if (service != null)
                {
                    return service;
                }
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
