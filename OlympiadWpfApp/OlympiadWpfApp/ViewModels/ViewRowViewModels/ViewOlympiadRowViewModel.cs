using System.Windows;
using OlympiadWpfApp.Commands;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.ViewModels.ViewRowViewModels;

public class ViewOlympiadRowViewModel
{
    private readonly Window _owner;
    private readonly OlympiadEntity _originalEntity; // на случай, если нужно откатить изменения(нажата кнопка Отмена)

    private bool CanExecuteOk => Entity.Name.Length > 0 &&
                                 Entity.Year > DateOnly.Parse("01.01.1900") &&
                                 Entity.City.Length > 0 &&
                                 Entity.HostCountry.Length > 0;

    public ViewOlympiadRowViewModel(Window owner, OlympiadEntity entityToEdit)
    {
        _owner = owner;
        _owner.DataContext = this;
        OkCommand = new DelegateCommand(_ => ExecuteOk(), _ => CanExecuteOk);
        CancelCommand = new DelegateCommand(_ => ExecuteCancel());
        Entity = entityToEdit;
        _originalEntity = Entity.Clone() as OlympiadEntity ?? throw new InvalidOperationException();
    }
    
    public OlympiadEntity Entity { get; }
    public Command OkCommand { get; set; }
    public Command CancelCommand { get; set; }

    private void ExecuteOk()
    {
        _owner.DialogResult = true;
        _owner.Close();
    }

    private void ExecuteCancel()
    {
        Entity.Name = _originalEntity.Name;
        Entity.Year = _originalEntity.Year;
        Entity.HostCountry = _originalEntity.HostCountry;
        Entity.City = _originalEntity.City;
        Entity.IsWinter = _originalEntity.IsWinter;
        _owner.Close();
    }
}