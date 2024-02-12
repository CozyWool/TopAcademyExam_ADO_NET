using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using OlympiadWpfApp.Converters;
using OlympiadWpfApp.DataAccess.Contexts;
using OlympiadWpfApp.DataAccess.Entities;
using OlympiadWpfApp.Extensions;
using OlympiadWpfApp.Views;

namespace OlympiadWpfApp.ViewModels;

public class ShowOlympiadTableViewModel : ShowTableViewModel, INotifyPropertyChanged
{
    private readonly OlympDbContext _olympDbContext;
    public ObservableCollection<OlympiadEntity> Entities { get; private set; }

    public ShowOlympiadTableViewModel(Window owner, OlympDbContext olympDbContext) : base(owner)
    {
        _olympDbContext = olympDbContext;
        GetData();
    }

    protected override void ExecuteEdit()
    {
        var index = SelectedIndex;
        var selectedEntity = Entities[index]; // пытался сделать клон сущности(чтобы в случае отмена откатить изменния), но получал ошибку с отслеживанием изменений, выкрутился костылями

        var window = new ViewOlympiadRowWindow(Owner);
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
        var window = new ViewOlympiadRowWindow(Owner);
        var olympiadEntity = new OlympiadEntity
        {
            Id = _olympDbContext.Olympiads.Any() ? _olympDbContext.Olympiads.OrderBy(x => x.Id).Last().Id + 1 : 1,
            Name = "",
            Year = DateOnly.Parse("01.01.1900"),
            HostCountry = "",
            City = "",
            IsWinter = false,
            IsDeleted = false,
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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}