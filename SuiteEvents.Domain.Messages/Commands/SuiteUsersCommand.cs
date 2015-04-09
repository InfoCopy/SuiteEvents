using System;

namespace SuiteEvents.Domain.Messages.Commands
{
    public class CreateSuiteUserCommand : Command
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

        public CreateSuiteUserCommand(Guid userId, string applicationName, string userName, string password, string email,
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

    public class UpdateSuiteUserCommand : Command
    {
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Cognome { get; private set; }

        public UpdateSuiteUserCommand(Guid id, string email, string nome, string cognome)
        {
            this.AggregateId = id;
            this.Email = email;
            this.Nome = nome;
            this.Cognome = cognome;
        }
    }
}
