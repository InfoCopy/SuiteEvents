using System;
using System.Diagnostics;
using System.Windows;

using Microsoft.Practices.Unity;
using SuiteEvents.Common.Infrastructures;
using SuiteEvents.Interfaces;
using SuiteEvents.Modules.MainMenu;
using SuiteEvents.Modules.ModuloUtenti;

namespace SuiteEvents
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;

            // Istanzio il contenitore principale
            IUnityContainer container = new UnityContainer();

            try
            {
                container.Resolve<SuiteEventsBoot>()
                    .RegisterModule(typeof(SuiteEventsModule))
                    .RegisterModule(typeof (MainMenuModule))
                    .RegisterModule(typeof(ModuloUtentiModule))
                    ;
            }
            catch (Exception ex)
            {
                this.WriteErrorInRegistryApplication(ex, "SuiteEvents.OnStartup.RegisterModule");
            }

            try
            {
                // start App
                container.Resolve<IShellSuiteEvents>().Show();
                container.Resolve<Controller>().Run();
            }
            catch (Exception ex)
            {
                this.WriteErrorInRegistryApplication(ex, "SuiteEvents.OnStartup.Run");
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            //suite4log.WriteExceptionLog("CurrentDomain_UnhandledException", ex);
            this.WriteErrorInRegistryApplication(ex, "CurrentDomain_UnhandledException");
        }

        public bool DoHandle { get; set; }
        private void Application_DispatcherUnhandledException(object sender,
                               System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Exception Caught",
                                    MessageBoxButton.OK, MessageBoxImage.Error);

            //suite4log.WriteExceptionLog("Application_DispatcherUnhandledException", e.Exception);

            this.WriteErrorInRegistryApplication(e.Exception, "Application_DispatcherUnhandledException");

            e.Handled = false;
        }

        private void WriteErrorInRegistryApplication(Exception ex, string procedure)
        {
            const string sourceName = "SuiteEvents.ExceptionLog";

            if (EventLog.SourceExists(sourceName)) return;

            EventLog.CreateEventSource(sourceName, "SuiteEvents");
            var eventLog = new EventLog
            {
                Source = sourceName
            };

            var message = string.Format("Exception: {0} \n\nStack: {1} - {2}", ex.Message, ex.StackTrace, procedure);
            eventLog.WriteEntry(message, EventLogEntryType.Error);
        }
    }
}
