using System.Windows;
using OlympiadWpfApp.ViewModels;

namespace OlympiadWpfApp.Views;

public partial class ShowTableWindow : Window
{
    public ShowTableWindow(Window owner)
    {
        Owner = owner;
        InitializeComponent();
    }
}