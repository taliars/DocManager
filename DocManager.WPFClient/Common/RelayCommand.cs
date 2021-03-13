using System;
using System.Windows.Input;

namespace DocManager.Infrastructure.Client.ViewModel.Common
{
        public class RelayCommand : ICommand
        {
            public RelayCommand(Action<object> action)
            {
                ExecuteDelegate = action;
            }

            private Predicate<object> CanExecuteDelegate { get; set; }
            private Action<object> ExecuteDelegate { get; set; }

            public bool CanExecute(object parameter)
            {
                return CanExecuteDelegate == null || CanExecuteDelegate(parameter);
            }
            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }
            public void Execute(object parameter)
            {
                ExecuteDelegate?.Invoke(parameter);
            }
    }
}
