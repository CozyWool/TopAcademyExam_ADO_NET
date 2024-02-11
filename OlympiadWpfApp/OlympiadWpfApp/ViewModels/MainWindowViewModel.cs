using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OlympiadWpfApp.Commands;

namespace OlympiadWpfApp.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private Window _owner;
    /* */
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
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}