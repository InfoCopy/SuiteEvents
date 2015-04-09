using System;

namespace SuiteEvents.Domain.Services.Dtos
{
    public class DtoSuiteUsers : DtoBase
    {
        public string ApplicationName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLocked { get; set; }
    }
}
