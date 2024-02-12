using System.Windows;
using OlympiadWpfApp.Commands;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.ViewModels.ViewRowViewModels;

public class ViewSportTypeRowViewModel
{
    private readonly Window _owner;
    private readonly SportTypeEntity _originalEntity; // на случай, если нужно откатить изменения(нажата кнопка Отмена)

    //private bool CanExecuteOk => Entity.Name.Length > 0; // т.к всего одно поле, то оно тут не работает

    public ViewSportTypeRowViewModel(Window owner, SportTypeEntity entityToEdit)
    {
        _owner = owner;
        _owner.DataContext = this;
        OkCommand = new DelegateCommand(_ => ExecuteOk());
        CancelCommand = new DelegateCommand(_ => ExecuteCancel());
        Entity = entityToEdit;
        _originalEntity = Entity.Clone() as SportTypeEntity ?? throw new InvalidOperationException();
    }

    public SportTypeEntity Entity { get; }
    public Command OkCommand { get; }
    public Command CancelCommand { get; }

    private void ExecuteOk()
    {
        if (Entity.Name.Length <= 0)
        {
            MessageBox.Show("Введите все данные!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        _owner.DialogResult = true;
        _owner.Close();
    }

    private void ExecuteCancel()
    {
        Entity.Name = _originalEntity.Name;
        _owner.Close();
    }
}