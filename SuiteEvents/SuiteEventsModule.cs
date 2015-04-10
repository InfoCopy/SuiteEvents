using Microsoft.Practices.Unity;

using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Domain.Abstracts;
using SuiteEvents.Domain.CommandHandlers;
using SuiteEvents.Domain.Messages.Commands;
using SuiteEvents.Interfaces;
using SuiteEvents.Providers.Abstracts;
using SuiteEvents.Providers.Concretes;
using SuiteEvents.Shell;

namespace SuiteEvents
{
    internal class SuiteEventsModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            // Register view models
            container.RegisterType<IShellSuiteEvents, ShellSuiteEventsViewModel>(
                new ContainerControlledLifetimeManager());

            #region Service
            //container.RegisterType<IServiceBus, InProcessBus>(
            //    new ContainerControlledLifetimeManager());
            container.RegisterType<ISuiteUsersProvider, SuiteUsersProvider>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IHandleCommand<CreateSuiteUserCommand>, SuiteUsersCommandHandlers>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IHandleCommand<UpdateSuiteUserCommand>, SuiteUsersCommandHandlers>(
                new ContainerControlledLifetimeManager());
            #endregion

            

            //#region UnitOfWork
            //container.RegisterType<IReadModelDatabase, ReadModelDatabase>(
            //    new ContainerControlledLifetimeManager());

            //try
            //{
            //    var repository = container.Resolve<IRepository>();
            //}
            //catch (System.Exception ex)
            //{
            //    var error = ex.Message;
            //}
            //#endregion

            
        }
    }
}
