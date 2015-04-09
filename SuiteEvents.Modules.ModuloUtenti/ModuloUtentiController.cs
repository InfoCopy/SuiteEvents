using System;

using Microsoft.Practices.Unity;
using SuiteEvents.Common.Infrastructures;
using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Common.Infrastructures.Modules;
using SuiteEvents.Modules.ModuloUtenti.Utenti.Interfaces;

namespace SuiteEvents.Modules.ModuloUtenti
{
    public class ModuloUtentiController : IModulesUtenti
    {
        private readonly IUnityContainer _container;

        private readonly IRegion _mainRegion;

        public ModuloUtentiController(
            IUnityContainer container,
            [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
        {
            this._container = container;
            this._mainRegion = mainRegion;
        }

        public void Run()
        {
            var moduloUtentiViewModel = this._container.Resolve<IModuloUtentiViewModel>();
            this._mainRegion.Context = moduloUtentiViewModel;
        }

        #region EventHandler
        public event EventHandler<EventArgs> CloseModuloUtentiInvoked;
        internal void InvokeCloseModuloUtenti(object parameter)
        {
            var handler = this.CloseModuloUtentiInvoked;
            if (handler != null) handler(this, new EventArgs());
        }
        #endregion
    }
}
