using System;
using CommonDomain.Core;

using SuiteEvents.Domain.Messages.Events;
using SuiteEvents.Domain.Resources.Exceptions;
using SuiteEvents.Domain.ValidationRules;

namespace SuiteEvents.Domain.Entities
{
    public class SuiteUsers : AggregateBase
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

        protected SuiteUsers()
        { }

        #region SuiteUser Create
        public SuiteUsers(Guid userId, string applicationName, string userName, string password, string email,
            string nome, string cognome)
        {
            if (userId == Guid.Empty)
                throw new Exception("UserId Obbligatorio!");

            if (String.IsNullOrEmpty(userName) || String.IsNullOrWhiteSpace(userName))
                throw new ArgumentException(DomainExceptions.UserNameNullException, "userName");

            if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
                throw new ArgumentException(DomainExceptions.PasswordNullException, "password");

            if (String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome))
                throw new ArgumentException(DomainExceptions.NomeNullException, "nome");

            if (String.IsNullOrEmpty(cognome) || String.IsNullOrWhiteSpace(cognome))
                throw new ArgumentException(DomainExceptions.CognomeNullException, "cognome");

            if (String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email))
                throw new ArgumentException(DomainExceptions.EmailNullException, "email");

            if (!DomainValidationRules.ValidateEmail(email))
                throw new ArgumentException(DomainExceptions.EmailWrongFormat, "email");

            this.RaiseEvent(new SuiteUserCreated(userId, applicationName, userName, password, email, nome, cognome));
        }

        private void Apply(SuiteUserCreated @event)
        {
            this.Id = @event.AggregateId;
            this.ApplicationName = @event.ApplicationName;
            this.UserName = @event.UserName;
            this.Password = @event.Password;
            this.Email = @event.Email;
            this.Nome = @event.Nome;
            this.Cognome = @event.Cognome;
            this.LastLoginDate = @event.LastLoginDate;
            this.CreationDate = @event.CreationDate;
            this.IsApproved = @event.IsApproved;
            this.IsLocked = @event.IsLocked;
        }
        #endregion

        #region SuiteUser Update
        public void UpdateSuiteUser(string email, string nome, string cognome)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email))
                throw new ArgumentException(DomainExceptions.EmailNullException, "email");

            if (String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome))
                throw new ArgumentException(DomainExceptions.NomeNullException, "nome");

            if (String.IsNullOrEmpty(cognome) || String.IsNullOrWhiteSpace(cognome))
                throw new ArgumentException(DomainExceptions.CognomeNullException, "cognome");

            if (!DomainValidationRules.ValidateEmail(email))
                throw new ArgumentException(DomainExceptions.EmailWrongFormat, "email");

            this.RaiseEvent(new SuiteUserUpdated(this.Id, email, nome, cognome));
        }

        private void Apply(SuiteUserUpdated @event)
        {
            this.Email = @event.Email;
            this.Nome = @event.Nome;
            this.Cognome = @event.Cognome;
        }
        #endregion
    }
}
