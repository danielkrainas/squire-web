namespace Squire.Web.Mvc
{
    using Microsoft.Practices.ServiceLocation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public static class ControllerBuilderExtensions
    {
        public static void UseContainerFactory(this ControllerBuilder builder, IServiceLocator locator)
        {
            builder.SetControllerFactory(new IocControllerFactory(locator));
        }
    }
}
