using System;
using Microsoft.Practices.Unity;

using SuiteEvents.Common.Infrastructures;
using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Common.Infrastructures.Modules;
using SuiteEvents.Modules.MainMenu.MainMenu.Interfaces;

namespace SuiteEvents.Modules.MainMenu
{
    public class MainMenuController : IModulesMainMenu
    {
        private readonly IUnityContainer _container;

        private readonly IRegion _mainRegion;

        public MainMenuController(
            IUnityContainer container,
            [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
        {
            this._container = container;
            this._mainRegion = mainRegion;
        }

        public void Run()
        {
            var mainMenuViewModel = this._container.Resolve<IMainMenuViewModel>();
            this._mainRegion.Context = mainMenuViewModel;
        }

        #region EventHandler
        public event EventHandler<EventArgs> ModuloUtentiInvoked;
        internal void InvokeModuloUtenti(object parameter)
        {
            var handler = this.ModuloUtentiInvoked;
            if (handler != null) handler(this, new EventArgs());
        }
        #endregion
    }
}
