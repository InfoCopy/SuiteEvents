using Microsoft.Practices.Unity;

using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Common.Infrastructures.Modules;
using SuiteEvents.Modules.MainMenu.MainMenu.Interfaces;
using SuiteEvents.Modules.MainMenu.MainMenu.ViewModels;

namespace SuiteEvents.Modules.MainMenu
{
    public class MainMenuModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IMainMenuViewModel, MainMenuViewModel>(
                new HierarchicalLifetimeManager());

            container.RegisterType<IModulesMainMenu, MainMenuController>(
                new HierarchicalLifetimeManager());
        }
    }
}
