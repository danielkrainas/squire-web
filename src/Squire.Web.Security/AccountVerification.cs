namespace Squire.Web.Security
{
    using Squire.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AccountVerification
    {
        public static AccountVerification MakeCompleted()
        {
            return new AccountVerification()
            {
                VerifiedOn = DateTime.Now
            };
        }

        public AccountVerification()
        {
            this.VerificationCode = CodeGenerator.Generate(CodeType.Distinct, 20);
        }

        public DateTime? VerifiedOn
        {
            get;
            set;
        }

        public string VerificationCode
        {
            get;
            set;
        }
    }
}
