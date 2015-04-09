using System.Windows;

using SuiteEvents.Common.Resources.Applications;

namespace SuiteEvents.Common.Resources.MessageBoxes
{
    public class MessageBoxFunctions
    {
        public static bool ShowDeleteMessageBox()
        {
            var messageBox = new MahAppsMessageBox();
            return messageBox.Show(MessagesResources.DeleteSelectedItem, ApplicationResources.ApplicationName, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        public static void ShowNothigToSaveMessageBox()
        {
            MessageBox.Show(MessagesResources.NothingToSaveMessage, Application.Current.MainWindow.Title);
        }

        #region GoogleCalendar
        public static bool ShowDeleteEventsBox()
        {
            var messageBox = new MahAppsMessageBox();
            return messageBox.Show(MessagesResources.DeleteEvents, ApplicationResources.ApplicationName, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        public static void ShowUpdateComplete()
        {
            var messageBox = new MahAppsMessageBox();
            messageBox.Show(MessagesResources.UpdateComplete, ApplicationResources.ApplicationName, MessageBoxButton.OK);
        }
        #endregion

        public static bool ShowCloseApplicationMessageBox()
        {
            var messageBox = new MahAppsMessageBox();
            return messageBox.Show(MessagesResources.CloseApplicationQuestion, ApplicationResources.ApplicationName, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    }
}
