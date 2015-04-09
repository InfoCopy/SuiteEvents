using System.Windows.Input;
using SuiteEvents.Common.Infrastructures;
using SuiteEvents.Common.Infrastructures.Modules;
using SuiteEvents.Modules.MainMenu.MainMenu.Interfaces;

namespace SuiteEvents.Modules.MainMenu.MainMenu.ViewModels
{
    internal class MainMenuViewModel : IMainMenuViewModel
    {
        private readonly MainMenuController _controller;

        private readonly ICommand _attivaModuloUtentiCommand;

        public MainMenuViewModel(IModulesMainMenu mainMenu)
        {
            this._controller = (MainMenuController)mainMenu;

            this._attivaModuloUtentiCommand = new CommandModel(this.OnAttivaModuloUtentiCommand);
        }

        #region Command
        public ICommand AttivaModuloUtentiCommand
        {
            get { return this._attivaModuloUtentiCommand; }
        }
        #endregion

        #region Private Methods
        private void OnAttivaModuloUtentiCommand(object parameter)
        {
            this._controller.InvokeModuloUtenti(parameter);
        }
        #endregion
    }
}
