using System;
using System.Diagnostics;
using System.Windows.Input;

namespace SuiteEvents.Common.Infrastructures
{
    public class CommandModel : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public CommandModel(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public CommandModel(Action<object> execute) : this(execute, null) { }

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        #endregion
    }
}
