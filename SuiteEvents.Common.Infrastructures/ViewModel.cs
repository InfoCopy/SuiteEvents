using System.ComponentModel;
using SuiteEvents.Common.Infrastructures.Interfaces;

namespace SuiteEvents.Common.Infrastructures
{
    public abstract class ViewModel : IViewModel, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
