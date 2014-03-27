namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using Squire.Validation;
    using System.Collections.Concurrent;

    public class RequestInterceptConfiguration
    {
        private readonly ConcurrentBag<IRequestInterceptor> interceptors;

        private readonly ConcurrentBag<IRequestLogger> loggers;

        private readonly ConcurrentBag<IRequestAuthenticationInterceptor> authenticationInterceptors;

        private readonly ConcurrentBag<IRequestAuthorizationInterceptor> authorizationInterceptors;

        public RequestInterceptConfiguration()
        {
            this.interceptors = new ConcurrentBag<IRequestInterceptor>();
            this.loggers = new ConcurrentBag<IRequestLogger>();
            this.authenticationInterceptors = new ConcurrentBag<IRequestAuthenticationInterceptor>();
            this.authorizationInterceptors = new ConcurrentBag<IRequestAuthorizationInterceptor>();
        }

        public IEnumerable<IRequestInterceptor> Interceptors
        {
            get
            {
                return this.interceptors;
            }
        }

        public IEnumerable<IRequestAuthorizationInterceptor> AuthorizationInterceptors
        {
            get
            {
                return this.authorizationInterceptors;
            }
        }

        public IEnumerable<IRequestAuthenticationInterceptor> AuthenticationInterceptors
        {
            get
            {
                return this.authenticationInterceptors;
            }
        }

        public IEnumerable<IRequestLogger> Loggers
        {
            get
            {
                return this.loggers;
            }
        }

        public void Register(IRequestInterceptor interceptor)
        {
            interceptor.VerifyParam("interceptor").IsNotNull();
            this.interceptors.Add(interceptor);
        }

        public void Register(IRequestAuthenticationInterceptor interceptor)
        {
            interceptor.VerifyParam("interceptor").IsNotNull();
            this.authenticationInterceptors.Add(interceptor);
        }

        public void Register(IRequestAuthorizationInterceptor interceptor)
        {
            interceptor.VerifyParam("interceptor").IsNotNull();
            this.authorizationInterceptors.Add(interceptor);
        }

        public void Register(IRequestLogger logger)
        {
            logger.VerifyParam("logger").IsNotNull();
            this.loggers.Add(logger);
        }
    }
}
