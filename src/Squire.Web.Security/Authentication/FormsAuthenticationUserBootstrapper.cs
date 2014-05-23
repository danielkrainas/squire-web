namespace Squire.Web.Security.Authentication
{
    using Squire.Security.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    public class FormsAuthenticationUserBootstrapper : IRequestAuthenticationInterceptor
    {
        public FormsAuthenticationUserBootstrapper()
        {
        }

        public void Authenticate(HttpContext context)
        {
            Authenticator.ResumeSession();
        }

        public void PostAuthenticate(HttpContext context)
        {

        }
    }
}
