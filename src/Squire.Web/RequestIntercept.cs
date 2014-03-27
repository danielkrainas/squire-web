namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class RequestIntercept
    {
        private static RequestInterceptConfiguration _globalConfig;

        public static RequestInterceptConfiguration GlobalConfig
        {
            get
            {
                var current = RequestIntercept._globalConfig;
                if (current == null)
                {
                    current = RequestIntercept._globalConfig = new RequestInterceptConfiguration();
                }

                return current;
            }
        }
    }
}
