namespace Squire.Web.Security.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Security;

    public interface IFormsAuthenticationService
    {
        bool Authenticate(string userName, string password);

        void SignOut();

        string Encrypt(FormsAuthenticationTicket ticket);

        FormsAuthenticationTicket Decrypt(string encryptedTicket);
    }
}
