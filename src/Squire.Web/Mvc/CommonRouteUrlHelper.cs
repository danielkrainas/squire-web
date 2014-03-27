namespace Squire.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using Squire.Validation;

    public class CommonRouteUrlHelper
    {
        private readonly UrlHelper urlHelper;

        public CommonRouteUrlHelper(UrlHelper urlHelper)
        {
            urlHelper.VerifyParam("urlHelper").IsNotNull();
            this.urlHelper = urlHelper;
        }

        public string Home()
        {
            return this.urlHelper.RouteUrl(CommonRoutes.Home);
        }
    }
}
