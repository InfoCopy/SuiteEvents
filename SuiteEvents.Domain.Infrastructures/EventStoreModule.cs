using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;

using Microsoft.Practices.Unity;

using NEventStore;
using NEventStore.Dispatcher;

using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Domain.Infrastructures.Concretes;

namespace SuiteEvents.Domain.Infrastructures
{
    public class EventStoreModule : IModule
    {
        private const string SqlConnectionStringName = "EventStore";

        public void Register(IUnityContainer container)
        {
            container.RegisterType<IConstructAggregates, AggregateFactory>(
                new ContainerControlledLifetimeManager());

            container.RegisterType<IDetectConflicts, ConflictDetector>(
                new ContainerControlledLifetimeManager());

            //var eventStore = container.Resolve<IDispatchCommits>();

            //var eventStoreRepository = new EventStoreRepository(container.Resolve<IStoreEvents>(),
            //    container.Resolve<IConstructAggregates>(), container.Resolve<IDetectConflicts>());
            //container.RegisterType(new EventStoreRepository(container.Resolve<IStoreEvents>(),
            //    container.Resolve<IConstructAggregates>(), container.Resolve<IDetectConflicts>()));

            //container.RegisterType<IDispatchCommits, eventStore> (
            //    new ContainerControlledLifetimeManager());
        }

        private IStoreEvents GetEventStore(IDispatchCommits bus)
        {
            return Wireup.Init()
                .UsingSqlPersistence(SqlConnectionStringName).InitializeStorageEngine()
                .UsingJsonSerialization().Compress()
                .UsingSynchronousDispatchScheduler().DispatchTo(bus)
                .Build();
        }
    }
}
