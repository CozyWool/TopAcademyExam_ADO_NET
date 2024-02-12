using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OlympiadWpfApp.DataAccess.Contexts;
using OlympiadWpfApp.DataAccess.Entities;
using OlympiadWpfApp.ViewModels.ViewRowViewModels;
using OlympiadWpfApp.Views.ViewRowViews;

namespace OlympiadWpfApp.ViewModels.ShowTableViewModels;

public sealed class ShowSportTypeTableViewModel : ShowTableViewModel
{
    private readonly OlympDbContext _olympDbContext;

    public ShowSportTypeTableViewModel(Window owner, OlympDbContext olympDbContext) : base(owner)
    {
        _olympDbContext = olympDbContext;
        GetData();
    }

    public ObservableCollection<SportTypeEntity> Entities { get; private set; } = null!;

    protected override void ExecuteEdit()
    {
        var index = SelectedIndex;
        var
            selectedEntity =
                Entities[index]; // пытался сделать клон сущности(чтобы в случае отмена откатить изменния), но получал ошибку с отслеживанием изменений, выкрутился костылями

        var window = new ViewSportTypeRowView(Owner);
        var viewModel = new ViewSportTypeRowViewModel(window, selectedEntity);

        if (window.ShowDialog() != true)
        {
            OnPropertyChanged(nameof(Entities)); // не обновляется вьюшка, хотя я поставил UpdateSourceTrigger
            return;
        }

        _olympDbContext.SportTypes.Update(selectedEntity);
    }

    protected override void ExecuteAdd()
    {
        var sportTypeEntity = new SportTypeEntity
        {
            Id = _olympDbContext.SportTypes.Any() ? _olympDbContext.SportTypes.OrderBy(x => x.Id).Last().Id + 1 : 1,
            Name = ""
        };

        var window = new ViewSportTypeRowView(Owner);
        var viewModel = new ViewSportTypeRowViewModel(window, sportTypeEntity);

        if (window.ShowDialog() != true) return;

        _olympDbContext.SportTypes.Add(viewModel.Entity);
        Entities.Add(viewModel.Entity);
    }

    protected override void ExecuteDelete()
    {
        _olympDbContext.SportTypes.Remove(Entities[SelectedIndex]);
        Entities.Remove(Entities[SelectedIndex]);
    }

    protected override void GetData()
    {
        Entities = new ObservableCollection<SportTypeEntity>(_olympDbContext.SportTypes
            .OrderBy(x => x.Id)
            .ToList());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}