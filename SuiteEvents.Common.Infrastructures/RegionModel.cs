using System.ComponentModel;
using SuiteEvents.Common.Infrastructures.Interfaces;

namespace SuiteEvents.Common.Infrastructures
{
    public class RegionModel : IRegion, INotifyPropertyChanged
    {
        private IViewModel _context;

        public IViewModel Context
        {
            get { return this._context; }
            set
            {
                this._context = value;
                this.InvokePropertyChanged("Context");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
