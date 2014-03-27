namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    public interface IRequestAuthorizationInterceptor
    {
        void Authorize(HttpContext context);

        void PostAuthorize(HttpContext context);
    }
}
