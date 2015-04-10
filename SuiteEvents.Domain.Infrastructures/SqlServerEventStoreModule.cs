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
    public class SqlServerEventStoreModule : IModule
    {
        //private const string SqlConnectionStringName = "EventStore";

        public void Register(IUnityContainer container)
        {
            container.RegisterType<IConstructAggregates, AggregateFactory>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IDetectConflicts, ConflictDetector>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IDispatchCommits, SuiteDispatcher>(
                new ContainerControlledLifetimeManager());
            
            var store = GetEventStore(container.Resolve<IDispatchCommits>());

            container.RegisterInstance(store);
            container.RegisterType<IRepository, EventStoreRepository>(
                new ContainerControlledLifetimeManager());
        }

        private static IStoreEvents GetEventStore(IDispatchCommits bus)
        {
            var connectionFactory =
                new ConnectionFactory(@"Data Source=.\SQLEXPRESS;Initial Catalog=SuiteEvents;Integrated Security=SSPI;",
                    "System.Data.SqlClient");

            //.UsingSqlPersistence(connectionFactory).InitializeStorageEngine()
            return Wireup.Init()
                .UsingInMemoryPersistence()
                .UsingJsonSerialization().Compress()
                .UsingSynchronousDispatchScheduler().DispatchTo(bus)
                .Build();
        }
    }
}
