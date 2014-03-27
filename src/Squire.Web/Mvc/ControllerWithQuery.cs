namespace Squire.Web.Security
{
    using Squire.Decoupled.Queries;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    public abstract class ControllerWithQuery : Controller
    {
        public ControllerWithQuery(IDispatchQuery queryDispatch)
        {
            this.Query = queryDispatch;
        }

        protected virtual IDispatchQuery Query
        {
            get;
            private set;
        }
    }
}
