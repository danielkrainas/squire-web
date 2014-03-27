namespace Squire.Web.Security
{
    using Squire.Web.Security.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using Squire.Validation;
    using Squire.Web;
    using Squire.Sentinel.Authentication;
    using Squire.Sentinel;

    public static class HttpApplicationExtensions
    {
        public static void EnableFormsAuthenticatorSupport(this HttpApplication httpApplication, IPlayerTokenizer tokenizer, Func<AuthenticationStrategyBuilder, AuthenticationStrategyBuilder> additionalOptions)
        {
            additionalOptions.VerifyParam("builderOptions").IsNotNull();
            var builder = new AuthenticationStrategyBuilder();
            builder.EnableFormsTracker(tokenizer);
            if (additionalOptions != null)
            {
                builder = additionalOptions(builder);
            }

            Authenticator.Assign(builder.Build());
        }
    }
}
