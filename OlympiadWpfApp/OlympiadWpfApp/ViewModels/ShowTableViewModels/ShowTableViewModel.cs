using System.Windows;
using OlympiadWpfApp.Commands;

namespace OlympiadWpfApp.ViewModels.ShowTableViewModels;

public abstract class ShowTableViewModel
{
    protected readonly Window Owner;

    protected ShowTableViewModel(Window owner)
    {
        Owner = owner;
        owner.DataContext = this;

        OkCommand = new DelegateCommand(_ => ExecuteOk());
        CancelCommand = new DelegateCommand(_ => ExecuteCancel());
        AddCommand = new DelegateCommand(_ => ExecuteAdd());
        EditCommand = new DelegateCommand(_ => ExecuteEdit(), _ => IsItemSelected);
        DeleteCommand = new DelegateCommand(_ => ExecuteDelete(), _ => IsItemSelected);
    }

    private bool IsItemSelected => SelectedIndex != -1;
    public Command OkCommand { get; }
    public Command CancelCommand { get; }
    public Command AddCommand { get; }
    public Command EditCommand { get; }
    public Command DeleteCommand { get; }
    public int SelectedIndex { get; set; }


    protected abstract void ExecuteEdit();
    protected abstract void ExecuteAdd();
    protected abstract void ExecuteDelete();
    protected abstract void GetData();

    private void ExecuteOk()
    {
        Owner.DialogResult = true;
        Owner.Close();
    }

    private void ExecuteCancel()
    {
        Owner.Close();
    }
}