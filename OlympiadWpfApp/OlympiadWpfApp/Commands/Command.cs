using System.Windows.Input;

namespace OlympiadWpfApp.Commands;

public abstract class Command : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        return CanExecuteCmd(parameter ?? throw new ArgumentNullException(nameof(parameter)));
    }

    public void Execute(object? parameter)
    {
        ExecuteCmd(parameter ?? throw new ArgumentNullException(nameof(parameter)));
    }

    protected virtual bool CanExecuteCmd(object parameter)
    {
        return true;
    }

    protected abstract void ExecuteCmd(object parameter);
}