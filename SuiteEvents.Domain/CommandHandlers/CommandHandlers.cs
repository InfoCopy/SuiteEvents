using System;

using CommonDomain.Persistence;

using SuiteEvents.Domain.Abstracts;
using SuiteEvents.Domain.Entities;
using SuiteEvents.Domain.Messages.Commands;

namespace SuiteEvents.Domain.CommandHandlers
{
    public class SuiteUsersCommandHandlers : CommandsHandler, IHandleCommand<CreateSuiteUserCommand>, IHandleCommand<UpdateSuiteUserCommand>
    {
        public SuiteUsersCommandHandlers(Func<IRepository> repository)
            : base(repository)
        {
        }

        void IHandleCommand<CreateSuiteUserCommand>.Handle(CreateSuiteUserCommand command)
        {
            var suiteUser = new SuiteUsers(command.AggregateId, command.ApplicationName, command.UserName,
                command.Password, command.Email, command.Nome, command.Cognome);
            Repository().Save(suiteUser, Guid.NewGuid());
        }

        public void Handle(UpdateSuiteUserCommand command)
        {
            var repo = Repository();

            var suiteUser = this.Get<SuiteUsers>(command.AggregateId, repo);
            suiteUser.UpdateSuiteUser(command.Email, command.Nome, command.Cognome);
            repo.Save(suiteUser, Guid.NewGuid());
        }
    }
}
