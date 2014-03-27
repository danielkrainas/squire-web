namespace Squire.Web.Security.Authentication
{
    using Squire.Sentinel;
    using Squire.Sentinel.Authentication;
    using Squire.Web;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class AuthenticationStrategyBuilderExtensions
    {
        public static AuthenticationStrategyBuilder EnableFormsTracker(this AuthenticationStrategyBuilder builder, IPlayerTokenizer tokenizer)
        {
            return builder.TrackWith(new FormsAuthenticationSessionTracker(new DefaultHttpContextProvider(), new FormsAuthenticationServiceAdapter(), tokenizer));
        }
    }
}
