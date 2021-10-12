using System;
using System.Windows.Input;

namespace Homework_13_bank_system.binaries
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            if (Execute != null)
            {
                execute = Execute;
                canExecute = CanExecute;
            }
        }
    }
}
