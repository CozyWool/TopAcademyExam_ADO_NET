using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OlympiadWpfApp.DataAccess.Contexts;
using OlympiadWpfApp.DataAccess.Entities;
using OlympiadWpfApp.ViewModels.ViewRowViewModels;
using OlympiadWpfApp.Views.ViewRowViews;

namespace OlympiadWpfApp.ViewModels.ShowTableViewModels;

public sealed class ShowParticipantTableViewModel : ShowTableViewModel
{
    private readonly OlympDbContext _olympDbContext;

    public ShowParticipantTableViewModel(Window owner, OlympDbContext olympDbContext) : base(owner)
    {
        _olympDbContext = olympDbContext;
        GetData();
    }

    public ObservableCollection<ParticipantEntity> Entities { get; private set; } = null!;

    protected override void ExecuteEdit()
    {
        var index = SelectedIndex;
        var
            selectedEntity =
                Entities[index]; // пытался сделать клон сущности(чтобы в случае отмена откатить изменния), но получал ошибку с отслеживанием изменений, выкрутился костылями

        var window = new ViewParticipantRowView(Owner);
        var viewModel = new ViewParticipantRowViewModel(window, selectedEntity);

        if (window.ShowDialog() != true)
        {
            OnPropertyChanged(nameof(Entities)); // не обновляется вьюшка, хотя я поставил UpdateSourceTrigger
            return;
        }

        _olympDbContext.Participants.Update(selectedEntity);
    }

    protected override void ExecuteAdd()
    {
        var participantEntity = new ParticipantEntity
        {
            Id = _olympDbContext.SportTypes.Any() ? _olympDbContext.Participants.OrderBy(x => x.Id).Last().Id + 1 : 1,
            Surname = "",
            Name = "",
            Patronymic = "",
            Birthdate = DateOnly.Parse("01.01.1900"),
            IsDeleted = false,
            Photo = new byte[] { },
            Country = ""
        };

        var window = new ViewParticipantRowView(Owner);
        var viewModel = new ViewParticipantRowViewModel(window, participantEntity);

        if (window.ShowDialog() != true) return;

        _olympDbContext.Participants.Add(viewModel.Entity);
        Entities.Add(viewModel.Entity);
    }

    protected override void ExecuteDelete()
    {
        Entities[SelectedIndex].IsDeleted = true; // Надеюсь правильно понял soft-delete механизм
        Entities.Remove(Entities[SelectedIndex]);
    }

    protected override void GetData()
    {
        Entities = new ObservableCollection<ParticipantEntity>(_olympDbContext.Participants
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.Id)
            .ToList());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}