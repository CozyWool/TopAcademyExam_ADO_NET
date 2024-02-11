using System.Windows;
using OlympiadWpfApp.ViewModels;

namespace OlympiadWpfApp.Views;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var mainWindow = new MainWindow();
        var mainWindowViewModel = new MainWindowViewModel(mainWindow);
        mainWindow.DataContext = mainWindowViewModel;
        mainWindow.Show();
    }
}