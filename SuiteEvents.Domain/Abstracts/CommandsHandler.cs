using System;
using CommonDomain.Core;
using CommonDomain.Persistence;

namespace SuiteEvents.Domain.Abstracts
{
    public abstract class CommandsHandler
    {
        protected readonly Func<IRepository> Repository;

        protected CommandsHandler(Func<IRepository> repository)
        {
            if (repository == null) 
                throw new ArgumentNullException("repository");

            this.Repository = repository;
        }

        public T Get<T>(Guid id, IRepository repo) where T : AggregateBase
        {
            var aggregate = repo.GetById<T>(id);
            if (aggregate == null)
                throw new Exception(string.Format("{0} not found", typeof(T).Name));

            return aggregate;
        }
    }
}
