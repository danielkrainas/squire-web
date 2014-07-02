namespace Squire.Web.Security
{
    using Squire.Security;
    using Squire.Security.Authorization;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HasRoleAttribute : IsPlayerAttribute
    {
        protected static IEnumerable<IRole> ParseRoles(string roles)
        {
            foreach (var role in roles.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                yield return Authorizer.Select(role.Trim());
            }
        }

        private readonly List<IRole> roleReferences;

        public HasRoleAttribute()
            : this("")
        {
        }

        public HasRoleAttribute(string roles)
        {
            this.Roles = roles;
            this.roleReferences = HasRoleAttribute.ParseRoles(roles).ToList();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (base.AuthorizeCore(httpContext) && httpContext.User.Identity.IsPlayer())
            {
                foreach(var role in this.roleReferences)
                {
                    if (!Authorizer.IsIn(httpContext.User.Identity.AsPlayer(), role))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
