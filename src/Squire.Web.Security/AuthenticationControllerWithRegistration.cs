namespace Squire.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Security;
    using Squire.Web;
    using Squire.Web.Security;
    using Squire.Validation;
    using System.Security.Cryptography;
    using Squire.Decoupled.Queries;
    using Squire.Security.Authentication;
    using Squire.Security;

    public abstract class AuthenticationControllerWithRegistration : AuthenticationController
    {
        public AuthenticationControllerWithRegistration(IDispatchQuery query)
            : base(query)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return this.View(new PlayerRegistrationRequest());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Register(PlayerRegistrationRequest registration)
        {
            if (this.ModelState.IsValid)
            {
                var player = Authenticator.Register(new RegistrationDetails(registration.DisplayName, registration.Email, registration.Password));
                if (player != null)
                {
                    Authenticator.StartSession(player, false);
                    return this.RedirectToRoute(CommonRoutes.Home);
                }
            }

            return this.View(registration);
        }
    }
}
