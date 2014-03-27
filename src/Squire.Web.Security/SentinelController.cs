namespace Squire.Web.Security
{
    using Squire.Sentinel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    public class SentinelController : Controller
    {
        public SentinelController()
        {
        }

        public virtual IPlayerPrincipal Player
        {
            get
            {
                return this.User;
            }
        }

        public virtual new IPlayerPrincipal User
        {
            get
            {
                return base.User as IPlayerPrincipal;
            }
        }
    }
}
