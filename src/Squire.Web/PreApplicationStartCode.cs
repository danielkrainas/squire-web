namespace Squire.Web
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    public static class PreApplicationStartCode
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(RequestInterceptBootstrapper));
        }
    }
}
