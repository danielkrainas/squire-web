namespace Squire.Web.Security
{
    using Squire.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using AbilityFacade = Squire.Sentinel.Abilities.Ability;
    using System.Reflection;
    using Squire.Sentinel.Abilities;
    using Squire.Sentinel;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HasAbilityAttribute : IsPlayerAttribute
    {
        public HasAbilityAttribute(Type ability)
        {
            ability.VerifyParam("ability").IsNotNull();
            if (!ability.Implements<IAbility>())
            {
                throw new ArgumentException(string.Format("'{0}' does not implement '{1}'.", ability, typeof(IAbility)), "ability");
            }

            this.Ability = ability;
        }

        public Type Ability
        {
            get;
            set;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (base.AuthorizeCore(httpContext) && httpContext.User.Identity.IsPlayer())
            {
                var principal = httpContext.User.AsPlayerPrincipal();
                var checkMethod = principal.GetType().GetMethod("CheckAbility").MakeGenericMethod(this.Ability);
                return (bool)checkMethod.Invoke(principal, null);
            }

            return false;
        }
    }
}
