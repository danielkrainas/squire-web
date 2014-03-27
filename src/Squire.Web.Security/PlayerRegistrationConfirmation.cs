namespace Squire.Web.Security
{
    using Squire.Sentinel;
    using Squire.Validation;

    public class PlayerRegistrationConfirmation
    {
        public PlayerRegistrationConfirmation(IPlayer user)
        {
            user.VerifyParam("user").IsNotNull();
            this.Email = user.Email;
        }

        public string Email
        {
            get;
            set;
        }
    }
}
