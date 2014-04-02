namespace Squire.Web.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    public static class UrlHelperExtensions
    {
        public static CommonRouteUrlHelper CommonRoutes(this UrlHelper urlHelper)
        {
            return new CommonRouteUrlHelper(urlHelper);
        }
        //public static string Script(this UrlHelper url, string scriptName)
        //{
            
        //}
    }
}
