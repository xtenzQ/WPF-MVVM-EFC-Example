using System;
using System.Windows.Input;

namespace ResearchersWPF.UI.Common
{
    public class CommandBase : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public CommandBase(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
        {
            _execute = executeDelegate;
            _canExecute = canExecuteDelegate;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        void ICommand.Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}