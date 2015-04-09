using Microsoft.Practices.Unity;

using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Common.Infrastructures.Modules;
using SuiteEvents.Modules.ModuloUtenti.Utenti.Interfaces;
using SuiteEvents.Modules.ModuloUtenti.Utenti.ViewModels;

namespace SuiteEvents.Modules.ModuloUtenti
{
    public class ModuloUtentiModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            #region DomainService
            #endregion

            #region ModuleResource
            container.RegisterType<IModuloUtentiViewModel, ModuloUtentiViewModel>(
                new HierarchicalLifetimeManager());
            
            container.RegisterType<IModulesUtenti, ModuloUtentiController>(
                new HierarchicalLifetimeManager());
            #endregion
        }
    }
}
