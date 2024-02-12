using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OlympiadWpfApp.Commands;
using OlympiadWpfApp.DataAccess.Contexts;
using OlympiadWpfApp.Extensions;
using OlympiadWpfApp.Models;
using OlympiadWpfApp.ViewModels.ShowTableViewModels;
using OlympiadWpfApp.Views;
using OlympiadWpfApp.Views.ShowTableView;

namespace OlympiadWpfApp.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private Window _owner;
    private readonly string _allOlympiadsString;

    private readonly OlympDbContext _dbContext;
    private DataView _queryResult = null!;

    private ObservableCollection<string> _sportTypes = null!;
    private ObservableCollection<string> _olympiads = null!;
    private ObservableCollection<string> _countries = null!;

    public ObservableCollection<string> Countries
    {
        get => _countries;
        set
        {
            _countries = value;
            OnPropertyChanged();
        }
    }


    public ObservableCollection<string> Olympiads
    {
        get => _olympiads;
        set
        {
            _olympiads = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> SportTypes
    {
        get => _sportTypes;
        set
        {
            _sportTypes = value;
            OnPropertyChanged();
        }
    }

    public string? SelectedCountry { get; set; }
    public string? SelectedOlympiad { get; set; }
    public string? SelectedSportType { get; set; }

    public DataView QueryResult
    {
        get => _queryResult;
        set
        {
            _queryResult = value;
            OnPropertyChanged();
        }
    }

    public Command ShowMedalTable { get; }
    public Command ShowMedalists { get; }
    public Command ShowMostGoldMedalsCountry { get; }
    public Command ShowMostGoldMedalsParticipant { get; }
    public Command ShowMostHostCountry { get; }
    public Command ShowCountryTeam { get; }
    public Command ShowCountryStats { get; }
    public Command ShowOlympiadTable { get; }
    public Command ShowSportTypeTable { get; }
    public Command ShowParticipantTable { get; }


    public MainWindowViewModel(Window owner)
    {
        _owner = owner;
        _allOlympiadsString = "Все олимпиады"; // TODO: можно через ресурсы сюда локализацию подключить

        var configuration = BuildConfiguration();
        _dbContext = new OlympDbContext(configuration);

        SportTypes = new ObservableCollection<string>(_dbContext.SportTypes.Select(x => x.Name).Distinct().ToList());
        Olympiads = new ObservableCollection<string>(_dbContext.Olympiads.Where(x => !x.IsDeleted)
            .Select(x => x.Name).Distinct().ToList()) {_allOlympiadsString};
        Countries = new ObservableCollection<string>(_dbContext.Participants.Where(x => !x.IsDeleted).Select(x => x.Country).Distinct()
            .ToList());

        ShowMedalTable = new DelegateCommand(_ => ExecuteShowMedalTable(), _ => NeedSelectedOlympiad());
        ShowMedalists = new DelegateCommand(_ => ExecuteShowMedalists(), _ => NeedSelectedOlympiad());
        ShowMostGoldMedalsCountry =
            new DelegateCommand(_ => ExecuteShowMostGoldMedalsCountry(), _ => NeedSelectedOlympiad());
        ShowMostHostCountry = new DelegateCommand(_ => ExecuteShowMostHostCountry());
        ShowMostGoldMedalsParticipant =
            new DelegateCommand(_ => ExecuteShowMostGoldMedalsParticipant(), _ => NeedSelectedSportType());
        ShowCountryTeam = new DelegateCommand(_ => ExecuteShowCountryTeam(), _ => NeedSelectedCountry());
        ShowCountryStats = new DelegateCommand(_ => ExecuteShowCountryStats(),
            _ => NeedSelectedCountry() && NeedSelectedOlympiad());
        ShowOlympiadTable = new DelegateCommand(_ => ExecuteShowOlympiadTable());
        ShowSportTypeTable = new DelegateCommand(_ => ExecuteShowSportTypeTable());
        ShowParticipantTable = new DelegateCommand(_ => ExecuteShowParticipantTable());
    }


    private bool NeedSelectedCountry()
    {
        return SelectedCountry != null;
    }

    private bool NeedSelectedOlympiad()
    {
        return SelectedOlympiad != null;
    }

    private bool NeedSelectedSportType()
    {
        return SelectedSportType != null;
    }

    private void ExecuteShowMedalTable()
    {
        if (SelectedOlympiad == _allOlympiadsString)
        {
            var query = from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
                select new {p, sp};
            QueryResult = (from q in query
                    group q by q.p.Country
                    into gr
                    select new MedalTableModel
                    {
                        Country = gr.Key,
                        GoldMedals = gr.Sum(x => x.sp.GoldMedals),
                        SilverMedals = gr.Sum(x => x.sp.SilverMedals),
                        BronzeMedals = gr.Sum(x => x.sp.BronzeMedals)
                    })
                .OrderByDescending(x => x.GoldMedals)
                .ToList().ToDataTable().DefaultView;
            return;
        }

        var query1 = from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                .Include(x => x.OlympiadParticipant)
                .ThenInclude(x => x!.OlympiadEntity)
            join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
            where p.OlympiadParticipant.OlympiadEntity.Name == SelectedOlympiad
            select new {p, sp};
        QueryResult = (from q in query1
                group q by q.p.Country
                into gr
                select new MedalTableModel
                {
                    Country = gr.Key,
                    GoldMedals = gr.Sum(x => x.sp.GoldMedals),
                    SilverMedals = gr.Sum(x => x.sp.SilverMedals),
                    BronzeMedals = gr.Sum(x => x.sp.BronzeMedals)
                })
            .OrderByDescending(x => x.GoldMedals)
            .ToList().ToDataTable().DefaultView;
    }

    private void ExecuteShowMedalists()
    {
        if (SelectedOlympiad == _allOlympiadsString)
        {
            QueryResult = (from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                    join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
                    select new
                    {
                        p.Country,
                        SportType = sp.SportTypeEntity.Name,
                        p.Surname,
                        p.Name,
                        p.Patronymic,
                        sp.GoldMedals,
                        sp.SilverMedals,
                        sp.BronzeMedals
                    })
                .OrderByDescending(x => x.GoldMedals)
                .ToList().ToDataTable().DefaultView;
            return;
        }

        QueryResult = (from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                    .Include(x => x.OlympiadParticipant)
                    .ThenInclude(x => x!.OlympiadEntity)
                join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
                where p.OlympiadParticipant.OlympiadEntity.Name == SelectedOlympiad
                select new
                {
                    p.Country,
                    SportType = sp.SportTypeEntity.Name,
                    p.Surname,
                    p.Name,
                    p.Patronymic,
                    sp.GoldMedals,
                    sp.SilverMedals,
                    sp.BronzeMedals
                })
            .OrderByDescending(x => x.GoldMedals)
            .ToList().ToDataTable().DefaultView;
    }

    private void ExecuteShowMostGoldMedalsCountry()
    {
        if (SelectedOlympiad == _allOlympiadsString)
        {
            var query = from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
                select new {p, sp};
            QueryResult = (from q in query
                    group q by q.p.Country
                    into gr
                    select new
                    {
                        Country = gr.Key,
                        GoldMedals = gr.Sum(x => x.sp.GoldMedals)
                    })
                .OrderByDescending(x => x.GoldMedals).Take(1)
                .ToList().ToDataTable().DefaultView;
            return;
        }

        var query1 = from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                .Include(x => x.OlympiadParticipant)
                .ThenInclude(x => x!.OlympiadEntity)
            join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
            where p.OlympiadParticipant.OlympiadEntity.Name == SelectedOlympiad
            select new {p, sp};
        QueryResult = (from q in query1
                group q by q.p.Country
                into gr
                select new
                {
                    Country = gr.Key,
                    GoldMedals = gr.Sum(x => x.sp.GoldMedals)
                })
            .OrderByDescending(x => x.GoldMedals).Take(1)
            .ToList().ToDataTable().DefaultView;
    }

    private void ExecuteShowMostGoldMedalsParticipant()
    {
        QueryResult = _dbContext.Participants.Where(x => !x.IsDeleted).Join(_dbContext.SportTypeParticipants, p => p.Id, sp => sp.ParticipantId,
                (p, sp) => new
                {
                    p.Country,
                    SportType = sp.SportTypeEntity.Name,
                    p.Surname,
                    p.Name,
                    p.Patronymic,
                    sp.GoldMedals,
                    sp.SilverMedals,
                    sp.BronzeMedals
                }).Where(x => x.SportType == SelectedSportType)
            .OrderByDescending(x => x.GoldMedals).Take(1)
            .ToList().ToDataTable().DefaultView;
    }

    private void ExecuteShowMostHostCountry()
    {
        QueryResult = _dbContext.Olympiads.Where(x => !x.IsDeleted).GroupBy(o => o.HostCountry, o => o,
                (country, count) => new
                {
                    Country = country,
                    Count = count.Count()
                })
            .OrderByDescending(x => x.Count).Take(1)
            .ToList().ToDataTable().DefaultView;
    }

    private void ExecuteShowCountryTeam()
    {
        QueryResult = _dbContext.Participants.Where(x => !x.IsDeleted)
            .Where(x => x.Country == SelectedCountry).Distinct()
            .Select(x => new
            {
                x.Id,
                x.Country,
                x.Surname,
                x.Name,
                x.Patronymic,
                x.Birthdate
            })
            .ToList().ToDataTable().DefaultView;
    }

    private void ExecuteShowCountryStats()
    {
        if (SelectedOlympiad == _allOlympiadsString)
        {
            var query = from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
                where p.Country == SelectedCountry
                select new {p, sp};
            QueryResult = (from q in query
                    group q by q.p.Country
                    into gr
                    select new MedalTableModel
                    {
                        Country = gr.Key,
                        GoldMedals = gr.Sum(x => x.sp.GoldMedals),
                        SilverMedals = gr.Sum(x => x.sp.SilverMedals),
                        BronzeMedals = gr.Sum(x => x.sp.BronzeMedals)
                    })
                .OrderByDescending(x => x.GoldMedals)
                .ToList().ToDataTable().DefaultView;
            return;
        }

        var query1 = from p in _dbContext.Participants.Where(x => !x.IsDeleted)
                .Include(x => x.OlympiadParticipant)
                .ThenInclude(x => x!.OlympiadEntity)
            join sp in _dbContext.SportTypeParticipants on p.Id equals sp.ParticipantId
            where p.OlympiadParticipant.OlympiadEntity.Name == SelectedOlympiad && p.Country == SelectedCountry
            select new {p, sp};
        QueryResult = (from q in query1
                group q by q.p.Country
                into gr
                select new MedalTableModel
                {
                    Country = gr.Key,
                    GoldMedals = gr.Sum(x => x.sp.GoldMedals),
                    SilverMedals = gr.Sum(x => x.sp.SilverMedals),
                    BronzeMedals = gr.Sum(x => x.sp.BronzeMedals)
                })
            .OrderByDescending(x => x.GoldMedals)
            .ToList().ToDataTable().DefaultView;
    }

    private void ExecuteShowOlympiadTable()
    {
        var window = new ShowOlympiadTableView(_owner);
        var viewModel = new ShowOlympiadTableViewModel(window, _dbContext);

        if (window.ShowDialog() == true)
        {
            Olympiads = new ObservableCollection<string>(_dbContext.Olympiads.Where(x => !x.IsDeleted)
                .Select(x => x.Name).Distinct().ToList()) {_allOlympiadsString};
            _dbContext.SaveChanges();
        }
        else
        {
            _dbContext.RejectChanges();
        }
    }

    private void ExecuteShowSportTypeTable()
    {
        var window = new ShowSportTypeTableView(_owner);
        var viewModel = new ShowSportTypeTableViewModel(window, _dbContext);

        if (window.ShowDialog() == true)
        {
            _dbContext.SaveChanges();
            SportTypes =
                new ObservableCollection<string>(_dbContext.SportTypes.Select(x => x.Name).Distinct().ToList());
        }
        else
        {
            _dbContext.RejectChanges();
        }
    }

    private void ExecuteShowParticipantTable()
    {
        var window = new ShowParticipantTableView(_owner);
        var viewModel = new ShowParticipantTableViewModel(window, _dbContext);

        if (window.ShowDialog() == true)
        {
            _dbContext.SaveChanges();
            Countries = new ObservableCollection<string>(_dbContext.Participants.Where(x => !x.IsDeleted).Select(x => x.Country).Distinct()
                .ToList());
        }
        else
        {
            _dbContext.RejectChanges();
        }
    }

    private IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}