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
    using Squire.Web.Mvc;
    using Squire.Validation;
    using System.Security.Cryptography;
    using Squire.Decoupled.Queries;
    using Squire.Security;
    using Squire.Security.Authentication;

    public abstract class AuthenticationController : ControllerWithQuery
    {
        public AuthenticationController(IDispatchQuery query)
            : base(query)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            if (this.Request.IsAuthenticated)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }

                return RedirectToRoute(CommonRoutes.Home);
            }

            return this.View(new LoginRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(LoginRequest request, string returnUrl)
        {
            var passwordHash = "";
            IPlayer player = null;
            using (var md5 = MD5.Create())
            {
                passwordHash = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}..{1}", request.Username, request.Password)))).Replace("-", string.Empty);
            }

            if (!this.Request.IsAuthenticated && (player = Authenticator.Validate(request.Username, request.Password)) == null)
            {
                return this.View(request);
            }

            Authenticator.StartSession(player, request.RememberMe);
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToRoute(CommonRoutes.Home);
        }

        [HttpGet]
        [IsPlayer]
        public virtual ActionResult Logout()
        {
            if (this.Request.IsAuthenticated)
            {
                Authenticator.EndSession();
            }

            return this.RedirectToRoute(CommonRoutes.Home);
        }

        [HttpGet]
        [IsPlayer]
        public virtual ActionResult Index()
        {
            return this.View(Authenticator.CurrentPlayer);
        }
    }
}
