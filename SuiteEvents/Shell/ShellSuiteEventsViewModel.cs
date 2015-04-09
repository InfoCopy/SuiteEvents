using System.Windows;
using System.Windows.Input;

using Microsoft.Practices.Unity;
using SuiteEvents.Common.Infrastructures;
using SuiteEvents.Common.Infrastructures.Interfaces;
using SuiteEvents.Common.Resources.MessageBoxes;
using SuiteEvents.Interfaces;

namespace SuiteEvents.Shell
{
    internal class ShellSuiteEventsViewModel : IShellSuiteEvents
    {
        private readonly IRegion _headerRegion;
        private readonly IRegion _mainRegion;

        private readonly ICommand _closeCommand;

        public ShellSuiteEventsViewModel(IUnityContainer container)
        {
            this._headerRegion = new RegionModel();
            this._mainRegion = new RegionModel();

            // Define UI regions
            container.RegisterInstance(
                RegionNames.HeaderRegion, this._headerRegion,
                new ContainerControlledLifetimeManager());

            container.RegisterInstance(
                RegionNames.MainRegion, this._mainRegion,
                new ContainerControlledLifetimeManager());

            // Define main region
            container.RegisterInstance(
                this._mainRegion,
                new ContainerControlledLifetimeManager());

            // Define header region
            container.RegisterInstance(
                this._headerRegion,
                new ContainerControlledLifetimeManager());

            this._closeCommand = new CommandModel(OnCloseCommand);
        }

        #region Public Properties
        public IRegion HeaderRegion
        {
            get { return this._headerRegion; }
        }

        public IRegion MainRegion
        {
            get { return this._mainRegion; }
        }
        #endregion

        public void Show()
        {
            var shellSuiteLabel = new ShellSuiteEvents
            {
                WindowState = WindowState.Maximized,
                DataContext = this
            };
            shellSuiteLabel.Show();
        }

        #region Command
        public ICommand CloseCommand
        {
            get { return this._closeCommand; }
        }

        private static void OnCloseCommand(object parameter)
        {
            if (MessageBoxFunctions.ShowCloseApplicationMessageBox())
                Application.Current.Shutdown();
        }
        #endregion
    }
}
