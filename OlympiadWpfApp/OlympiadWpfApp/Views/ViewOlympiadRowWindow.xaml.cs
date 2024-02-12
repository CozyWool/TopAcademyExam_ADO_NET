using System.Windows;

namespace OlympiadWpfApp.Views;

public partial class ViewOlympiadRowWindow : Window
{
    public ViewOlympiadRowWindow(Window owner)
    {
        Owner = owner;
        InitializeComponent();
    }
}