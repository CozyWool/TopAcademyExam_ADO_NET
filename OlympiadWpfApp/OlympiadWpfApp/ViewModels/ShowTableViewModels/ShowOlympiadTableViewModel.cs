using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OlympiadWpfApp.DataAccess.Contexts;
using OlympiadWpfApp.DataAccess.Entities;
using OlympiadWpfApp.ViewModels.ViewRowViewModels;
using OlympiadWpfApp.Views.ViewRowViews;

namespace OlympiadWpfApp.ViewModels.ShowTableViewModels;

public sealed class ShowOlympiadTableViewModel : ShowTableViewModel, INotifyPropertyChanged
{
    private readonly OlympDbContext _olympDbContext;

    public ShowOlympiadTableViewModel(Window owner, OlympDbContext olympDbContext) : base(owner)
    {
        _olympDbContext = olympDbContext;
        GetData();
    }

    public ObservableCollection<OlympiadEntity> Entities { get; private set; } = null!;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected override void ExecuteEdit()
    {
        var index = SelectedIndex;
        var
            selectedEntity =
                Entities[index]; // пытался сделать клон сущности(чтобы в случае отмена откатить изменния), но получал ошибку с отслеживанием изменений, выкрутился костылями

        var window = new ViewOlympiadRowView(Owner);
        var viewModel = new ViewOlympiadRowViewModel(window, selectedEntity);

        if (window.ShowDialog() != true)
        {
            OnPropertyChanged(nameof(Entities)); // не обновляется вьюшка, хотя я поставил UpdateSourceTrigger
            return;
        }

        _olympDbContext.Olympiads.Update(selectedEntity);
    }

    protected override void ExecuteAdd()
    {
        var window = new ViewOlympiadRowView(Owner);
        var olympiadEntity = new OlympiadEntity
        {
            Id = _olympDbContext.Olympiads.Any() ? _olympDbContext.Olympiads.OrderBy(x => x.Id).Last().Id + 1 : 1,
            Name = "",
            Year = DateOnly.Parse("01.01.1900"),
            HostCountry = "",
            City = "",
            IsWinter = false,
            IsDeleted = false
        };

        var viewModel = new ViewOlympiadRowViewModel(window, olympiadEntity);

        if (window.ShowDialog() != true) return;

        _olympDbContext.Olympiads.Add(viewModel.Entity);
        Entities.Add(viewModel.Entity);
    }

    protected override void ExecuteDelete()
    {
        Entities[SelectedIndex].IsDeleted = true; // Надеюсь правильно понял soft-delete механизм
        Entities.Remove(Entities[SelectedIndex]);
    }

    protected override void GetData()
    {
        Entities = new ObservableCollection<OlympiadEntity>(_olympDbContext.Olympiads
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.Id)
            .ToList());
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}