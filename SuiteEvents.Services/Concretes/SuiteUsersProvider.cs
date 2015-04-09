using System;

using SuiteEvents.Domain.Infrastructures.Abstracts;
using SuiteEvents.Domain.Messages.Commands;
using SuiteEvents.Providers.Abstracts;

namespace SuiteEvents.Providers.Concretes
{
    public class SuiteUsersProvider : ISuiteUsersProvider
    {
        private readonly IServiceBus _serviceBus;

        public SuiteUsersProvider(IServiceBus serviceBus)
        {
            this._serviceBus = serviceBus;
        }

        public void CreateSuiteUser(string userName, string password, string applicationName, string nome, string cognome, string email)
        {
            var userId = Guid.NewGuid(); 
            this._serviceBus.Send(new CreateSuiteUserCommand(userId, applicationName, userName, password, email, nome, cognome));
        }
    }
}
