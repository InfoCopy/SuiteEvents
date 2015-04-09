using Microsoft.Practices.Unity;
using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Common.Infrastructures.Modules;

namespace SuiteEvents
{
    internal class Controller : IController
    {
        private readonly IUnityContainer _container;

        private IUnityContainer _sessionContainer;

        public Controller(
            IUnityContainer container)
        {
            this._container = container;
        }

        public void Run()
        {
            // create nested (session) container
            this._sessionContainer = this._container.CreateChildContainer();

            // avvio il menu
            this.RunMainMenu();
        }

        #region MainMenu
        private void RunMainMenu()
        {
            // creo MainMenu
            var mainMenu = this._sessionContainer.Resolve<IModulesMainMenu>();
            // registro il menu come sessione Singleton
            this._sessionContainer.RegisterInstance(
                mainMenu, new ContainerControlledLifetimeManager());
            
            // Imposto gli event handlers del menu
            mainMenu.ModuloUtentiInvoked += mainMenu_ModuloUtentiInvoked;

            // Avvio il menu
            mainMenu.Run();
        }

        private void CleanMainMenuEvents(object sender)
        {
            var mainMenu = sender as IModulesMainMenu;

            if (mainMenu == null) return;

            mainMenu.ModuloUtentiInvoked -= mainMenu_ModuloUtentiInvoked;
        }
        #endregion

        #region Modulo Utenti
        private void mainMenu_ModuloUtentiInvoked(object sender, System.EventArgs e)
        {
            this.CleanMainMenuEvents(sender);

            var moduloUtenti = this._sessionContainer.Resolve<IModulesUtenti>();
            this._container.RegisterInstance(moduloUtenti);

            moduloUtenti.CloseModuloUtentiInvoked += moduloUtenti_CloseModuloUtentiInvoked;
            moduloUtenti.Run();
        }

        private void moduloUtenti_CloseModuloUtentiInvoked(object sender, System.EventArgs e)
        {
            var moduloUtenti = sender as IModulesUtenti;

            if (moduloUtenti == null) return;

            moduloUtenti.CloseModuloUtentiInvoked -= moduloUtenti_CloseModuloUtentiInvoked;

            this.RunMainMenu();
        }
        #endregion
    }
}
