namespace Squire.Web.Security
{
    using Squire.Sentinel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IsPlayerAttribute : AuthorizeAttribute
    {
        public IsPlayerAttribute()
        {
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var player = httpContext.User as IPlayerPrincipal;
            return player != null && !player.IsGuest;
        }
    }
}
