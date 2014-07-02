namespace Squire.Web.Security
{
    using Squire.Security;
    using Squire.Security.Authentication;
    using Squire.Setup;
    using Squire.Validation;
    using Squire.Web.Security.Authentication;
    using System;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Routing;

    public static class AppSetupSecurityExtensions
    {
        public static IAppSetup<HttpApplication> EnableFormsAuthentication<T>(this IAppSetup<HttpApplication> setup, IPlayerTokenizer tokenizer, Expression<Func<AuthenticationStrategyBuilder, AuthenticationStrategyBuilder>> additionalOptions)
        {
            additionalOptions.VerifyParam("additionalOptions").IsNotNull();
            var builder = new AuthenticationStrategyBuilder();
            builder.EnableFormsTracker(tokenizer);
            if (additionalOptions != null)
            {
                builder = additionalOptions.Compile().Invoke(builder);
            }

            Authenticator.Assign(builder.Build());
            RequestIntercept.GlobalConfig.Register(new FormsAuthenticationUserBootstrapper());
            return setup;
        }

        public static IAdvancedAppSetup<HttpApplication, RouteCollection> MapAccountRelated(this IAdvancedAppSetup<HttpApplication, RouteCollection> setup, string controllerName = "Account", string controllerUrlPath = "account/", string[] namespaces = null)
        {
            setup.Advanced.MapAccountRoutes(controllerName, controllerUrlPath, namespaces, false);
            return setup;
        }

        public static IAdvancedAppSetup<HttpApplication, RouteCollection> MapAccountRelatedWithRegistration(this IAdvancedAppSetup<HttpApplication, RouteCollection> setup, string controllerName = "Account", string controllerUrlPath = "account/", string[] namespaces = null)
        {
            setup.Advanced.MapAccountRoutes(controllerName, controllerUrlPath, namespaces, true);
            return setup;
        }
    }
}
