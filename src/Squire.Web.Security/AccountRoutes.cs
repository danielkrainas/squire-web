namespace Squire.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Routing;
    using System.Web.Mvc;

    public static class AccountRoutes
    {
        public static readonly string Registration = "account_registration";

        public static readonly string Profile = "account_profile";

        public static readonly string Login = "account_login";

        public static readonly string Logout = "account_logout";
    }
}
