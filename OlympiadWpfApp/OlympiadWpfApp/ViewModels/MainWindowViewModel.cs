using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Extensions.Configuration;
using OlympiadWpfApp.Commands;
using OlympiadWpfApp.DataAccess.Contexts;

namespace OlympiadWpfApp.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private Window _owner;

    private OlympDbContext _dbContext;

    // public ObservableCollection<string> Countries
    // {
    //     get => _dbContext.;
    // }

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
        //ShowMedalTable = new DelegateCommand();
        
        var configuration = BuildConfiguration();
        _dbContext = new OlympDbContext(configuration);
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