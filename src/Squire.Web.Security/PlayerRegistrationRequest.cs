namespace Squire.Web.Security
{
    public class PlayerRegistrationRequest
    {
        public PlayerRegistrationRequest()
        {
            this.DisplayName = string.Empty;
            this.Password = string.Empty;
            this.Email = string.Empty;
            this.PasswordConfirmation = string.Empty;
        }

        public string DisplayName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string PasswordConfirmation
        {
            get;
            set;
        }
    }
}
