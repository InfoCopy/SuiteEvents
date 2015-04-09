using System;

namespace SuiteEvents.Domain.Messages.Events
{
    public class SuiteUserCreated : Event
    {
        public string ApplicationName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public DateTime? LastLoginDate { get; private set; }
        public DateTime? CreationDate { get; private set; }
        public bool? IsApproved { get; private set; }
        public bool? IsLocked { get; private set; }

        public SuiteUserCreated(Guid userId, string applicationName, string userName, string password, string email,
            string nome, string cognome)
        {
            this.AggregateId = userId;
            this.ApplicationName = applicationName;
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.Nome = nome;
            this.Cognome = cognome;
            this.LastLoginDate = new DateTime(2000, 1, 1);
            this.CreationDate = DateTime.Now;
            this.IsApproved = true;
            this.IsLocked = true;
        }
    }

    public class SuiteUserUpdated : Event
    {
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Cognome { get; private set; }

        public SuiteUserUpdated(Guid id, string email, string nome, string cognome)
        {
            this.AggregateId = id;
            this.Email = email;
            this.Nome = nome;
            this.Cognome = cognome;
        }
    }
}
