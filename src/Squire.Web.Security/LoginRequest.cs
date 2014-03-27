namespace Squire.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoginRequest
    {
        public LoginRequest()
        {
            this.Username = null;
            this.Password = null;
            this.RememberMe = false;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool RememberMe
        {
            get;
            set;
        }
    }
}
