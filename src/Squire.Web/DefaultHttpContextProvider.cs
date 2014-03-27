namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    public class DefaultHttpContextProvider : IHttpContextProvider
    {
        public DefaultHttpContextProvider()
        {
        }

        public HttpContextBase GetCurrent()
        {
            return new HttpContextWrapper(HttpContext.Current);
        }
    }
}
