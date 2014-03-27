namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    public interface IRequestInterceptor
    {
        void BeginRequest(HttpContext context);

        void EndRequest(HttpContext context);
    }
}
