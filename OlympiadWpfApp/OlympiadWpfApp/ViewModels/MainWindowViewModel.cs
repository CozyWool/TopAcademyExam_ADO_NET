using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Extensions.Configuration;
using OlympiadWpfApp.Commands;
using OlympiadWpfApp.DataAccess.Contexts;

namespace OlympiadWpfApp.ViewModels;

public static class ListExtensions
{
    public static DataTable ToDataTable<T>(this IList<T> data) // со stackoverflow взято
    {
        PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }

        return table;
    }
}

public class MainWindowViewModel : INotifyPropertyChanged
{
    private Window _owner;
    private readonly string allOlympiadsString;

    private readonly OlympDbContext _dbContext;
    private DataView _queryResult;

    public ObservableCollection<string> Countries =>
        new(_dbContext.Participants.Select(x => x.Country).Distinct().ToList());

    public ObservableCollection<string> Olympiads
    {
        get
        {
            var result = new ObservableCollection<string>(_dbContext.Olympiads.Select(x => x.Name).Distinct().ToList());
            result.Add(allOlympiadsString);
            return result;
        }
    }

    public string? SelectedCountry { get; set; }
    public string? SelectedOlympiad { get; set; }

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


    public MainWindowViewModel(Window owner)
    {
        _owner = owner;
        allOlympiadsString = "Все олимпиады"; // TODO: можно через ресурсы сюда локализацию подключить
        ShowMedalTable = new DelegateCommand(_ => ExecuteShowMedalTable(), _ => NeedSelectedOlympiad());

        var configuration = BuildConfiguration();
        _dbContext = new OlympDbContext(configuration);
    }

    private bool NeedSelectedCountry()
    {
        return SelectedCountry != null;
    }

    private bool NeedSelectedOlympiad()
    {
        return SelectedOlympiad != null;
    }

    private void ExecuteShowMedalTable()
    {
        if (SelectedOlympiad == allOlympiadsString)
        {
            QueryResult = _dbContext.Participants.GroupBy(p => p.Country).Join(_dbContext.SportTypeParticipants, p => p.Id,
                sp => sp.ParticipantId,
                (p, sp) => new
                {
                    Country = p.Country,
                    GoldMedals = sp.GoldMedals,
                    SilverMedals = sp.SilverMedals,
                    BronzeMedals = sp.BronzeMedals
                }).ToList().ToDataTable().DefaultView;
            return;
        }

        QueryResult = _dbContext.Participants
            .Join(_dbContext.OlympiadParticipants, p => p.Id, op => op.ParticipantId,
                (p, op) => new
                {
                    Participant = p, OlympName = op.OlympiadEntity.Name
                })
            .Where(x => x.OlympName == SelectedOlympiad).Join(_dbContext.SportTypeParticipants, p => p.Participant.Id,
                sp => sp.ParticipantId,
                (p, sp) => new
                {
                    Country = p.Participant.Country,
                    GoldMedals = sp.GoldMedals,
                    SilverMedals = sp.SilverMedals,
                    BronzeMedals = sp.BronzeMedals
                })
            .ToList()
            .ToDataTable()
            .DefaultView;
    }

    private void ExecuteShowMedalists()
    {
        if (SelectedOlympiad == allOlympiadsString)
        {
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