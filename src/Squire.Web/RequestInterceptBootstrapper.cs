namespace Squire.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using Squire.Validation;

    public class RequestInterceptBootstrapper : IHttpModule
    {
        private HttpApplication application;

        private readonly RequestInterceptConfiguration config;

        public RequestInterceptBootstrapper()
            : this(RequestIntercept.GlobalConfig)
        {
        }

        public RequestInterceptBootstrapper(RequestInterceptConfiguration config)
        {
            config.VerifyParam("config").IsNotNull();
            this.config = config;
        }

        public void Init(HttpApplication context)
        {
            this.application = context;
            context.BeginRequest += this.OnBeginRequest;
            context.AuthenticateRequest += this.OnAuthenticateRequest;
            context.LogRequest += this.OnLogRequest;
            context.AuthorizeRequest += this.OnAuthorizeRequest;
            context.AuthenticateRequest += this.OnAuthenticateRequest;
            context.PostAuthenticateRequest += this.OnPostAuthenticateRequest;
            context.PostAuthorizeRequest += this.OnPostAuthorizeRequest;
            context.EndRequest += this.OnEndRequest;
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            foreach (var interceptor in this.config.Interceptors)
            {
                interceptor.EndRequest(this.application.Context);
            }
        }

        private void OnLogRequest(object sender, EventArgs e)
        {
            foreach (var logger in this.config.Loggers)
            {
                logger.Log(this.application.Context);
            }
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            foreach (var interceptor in this.config.Interceptors)
            {
                interceptor.BeginRequest(this.application.Context);
            }
        }

        private void OnAuthenticateRequest(object sender, EventArgs e)
        {
            foreach (var interceptor in this.config.AuthenticationInterceptors)
            {
                interceptor.Authenticate(this.application.Context);
            }
        }

        private void OnAuthorizeRequest(object sender, EventArgs e)
        {
            foreach (var interceptor in this.config.AuthorizationInterceptors)
            {
                interceptor.Authorize(this.application.Context);
            }
        }

        private void OnPostAuthorizeRequest(object sender, EventArgs e)
        {
            foreach (var interceptor in this.config.AuthorizationInterceptors)
            {
                interceptor.PostAuthorize(this.application.Context);
            }
        }

        public void OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            foreach (var interceptor in this.config.AuthenticationInterceptors)
            {
                interceptor.PostAuthenticate(this.application.Context);
            }
        }

        public void Dispose()
        {

        }
    }
}
