namespace Squire.Web.Security.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Security;

    public class FormsAuthenticationServiceAdapter : IFormsAuthenticationService
    {
        public FormsAuthenticationServiceAdapter()
        {
        }

        public bool Authenticate(string userName, string password)
        {
            return FormsAuthentication.Authenticate(userName, password);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public string Encrypt(FormsAuthenticationTicket ticket)
        {
            return FormsAuthentication.Encrypt(ticket);
        }

        public FormsAuthenticationTicket Decrypt(string encryptedTicket)
        {
            return FormsAuthentication.Decrypt(encryptedTicket);
        }
    }
}
