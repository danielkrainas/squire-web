namespace Squire.Web.Security.Authentication
{
    using Squire.Web;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using Squire.Validation;
    using System.Threading;
    using System.Web.Security;
    using Squire.Security.Authentication;
    using Squire.Security;

    public class FormsAuthenticationSessionTracker : ISessionTracker
    {
        private readonly IHttpContextProvider httpProvider;

        private readonly IPlayerTokenizer tokenizer;

        private readonly IFormsAuthenticationService forms;

        public FormsAuthenticationSessionTracker(IHttpContextProvider httpProvider, IFormsAuthenticationService forms, IPlayerTokenizer tokenizer)
        {
            httpProvider.VerifyParam("httpProvider").IsNotNull();
            tokenizer.VerifyParam("tokenizer").IsNotNull();
            forms.VerifyParam("forms").IsNotNull();
            this.httpProvider = httpProvider;
            this.tokenizer = tokenizer;
            this.forms = forms;
        }

        public IPlayerPrincipal Restore()
        {
            IPlayer player = null;
            var context = this.httpProvider.GetCurrent();
            var roles = Enumerable.Empty<string>();
            var authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
            {
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                {
                    player = this.tokenizer.Redeem(ticket.UserData);
                }
            }

            if (player == null)
            {
                player = new GuestPlayer();
            }

            var session = new PlayerPrincipal(player, roles);
            context.User = session;
            Thread.CurrentPrincipal = session;
            return session;
        }

        public IPlayerPrincipal Start(IPlayer player, IEnumerable<string> roles, bool persist)
        {
            var context = this.httpProvider.GetCurrent();
            var session = new PlayerPrincipal(player, Enumerable.Empty<string>());
            if (context != null)
            {
                context.User = session;
            }

            Thread.CurrentPrincipal = session;
            var ticket = new FormsAuthenticationTicket(0, player.Name, DateTime.Now, DateTime.Now.AddMinutes(20), persist, this.tokenizer.GetToken(player));
            var token = this.forms.Encrypt(ticket);
            context.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, token));
            return session;
        }

        public void End()
        {
            var context = this.httpProvider.GetCurrent();
            if (context != null && context.User.Identity.IsAuthenticated)
            {
                context.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-20);
                context.User = new PlayerPrincipal(new GuestPlayer(), Enumerable.Empty<string>());
                Thread.CurrentPrincipal = context.User;
            }
        }
    }
}
