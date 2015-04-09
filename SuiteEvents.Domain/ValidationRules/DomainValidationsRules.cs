using System.Text.RegularExpressions;

namespace SuiteEvents.Domain.ValidationRules
{
    public static class DomainValidationRules
    {
        private const string EmailPattern =
            @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public static bool ValidateEmail(string email)
        {
            Match match = Regex.Match(email, EmailPattern);
            return match.Success;
        }
    }
    
}
