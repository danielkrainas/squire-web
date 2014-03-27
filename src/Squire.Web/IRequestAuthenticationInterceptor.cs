namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    public interface IRequestAuthenticationInterceptor
    {
        void Authenticate(HttpContext context);

        void PostAuthenticate(HttpContext context);
    }
}
