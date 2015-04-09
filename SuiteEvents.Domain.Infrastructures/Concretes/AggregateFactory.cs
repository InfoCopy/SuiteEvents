using System;
using CommonDomain;
using CommonDomain.Persistence;

namespace SuiteEvents.Domain.Infrastructures.Concretes
{
    public class AggregateFactory : IConstructAggregates
    {
        public IAggregate Build(Type type, Guid id, IMemento snapshot)
        {
            return Activator.CreateInstance(type) as IAggregate;
        }
    }
}
