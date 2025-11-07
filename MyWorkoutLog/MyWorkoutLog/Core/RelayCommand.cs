using System.Windows.Input;

namespace MyWorkoutLog.Core;

public class RelayCommand : ICommand
{
    // boolean based on whether or not matching criteria is true
    private readonly Predicate<object> _canExecute;
    // encapsulation of method with single parameter and no return value
    private readonly Action<object> _execute;

    public RelayCommand(Action<object> execute,Predicate<object> canExecute)
    {
        _canExecute = canExecute;
        _execute = execute;
    }
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }
}