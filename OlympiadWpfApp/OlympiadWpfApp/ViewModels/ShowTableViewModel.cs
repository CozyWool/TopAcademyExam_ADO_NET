using System.Windows;
using OlympiadWpfApp.Commands;

namespace OlympiadWpfApp.ViewModels;

public abstract class ShowTableViewModel
{
    private bool IsItemSelected => SelectedIndex != -1;
    protected readonly Window Owner;
    public Command OkCommand { get; }
    public Command CancelCommand { get; }
    public Command AddCommand { get; }
    public Command EditCommand { get; }
    public Command DeleteCommand { get; }
    public int SelectedIndex { get; set; }

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