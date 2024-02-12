using System.Windows;
using OlympiadWpfApp.Commands;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.ViewModels.ViewRowViewModels;

public class ViewParticipantRowViewModel
{
    private readonly Window _owner;
    private readonly ParticipantEntity _originalEntity; // на случай, если нужно откатить изменения(нажата кнопка Отмена)

    private bool CanExecuteOk => Entity.Surname.Length > 0 &&
                                 Entity.Name.Length > 0 &&
                                 Entity.Patronymic.Length > 0 &&
                                 Entity.Birthdate > DateOnly.Parse("01.01.1900") &&
                                 Entity.Country.Length > 0;

    public ViewParticipantRowViewModel(Window owner, ParticipantEntity entityToEdit)
    {
        _owner = owner;
        _owner.DataContext = this;
        OkCommand = new DelegateCommand(_ => ExecuteOk(), _ => CanExecuteOk);
        CancelCommand = new DelegateCommand(_ => ExecuteCancel());
        Entity = entityToEdit;
        _originalEntity = Entity.Clone() as ParticipantEntity ?? throw new InvalidOperationException();
    }
    
    public ParticipantEntity Entity { get; }
    public Command OkCommand { get; }
    public Command CancelCommand { get; }

    private void ExecuteOk()
    {
        _owner.DialogResult = true;
        _owner.Close();
    }

    private void ExecuteCancel()
    {
        Entity.Surname = _originalEntity.Surname;
        Entity.Name = _originalEntity.Name;
        Entity.Patronymic = _originalEntity.Patronymic;
        Entity.Birthdate = _originalEntity.Birthdate;
        Entity.Country = _originalEntity.Country;
        _owner.Close();
    }
}