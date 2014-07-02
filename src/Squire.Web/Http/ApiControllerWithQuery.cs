namespace Squire.Web.Http
{
    using Squire.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Http;
    using Squire.Decoupled.Queries;

    public abstract class ApiControllerWithQuery : ApiController
    {
        public ApiControllerWithQuery(IDispatchQuery queryDispatcher)
        {
            queryDispatcher.VerifyParam("queryDispatcher").IsNotNull();
            this.Query = queryDispatcher;
        }

        protected virtual IDispatchQuery Query
        {
            get;
            private set;
        }
    }
}
