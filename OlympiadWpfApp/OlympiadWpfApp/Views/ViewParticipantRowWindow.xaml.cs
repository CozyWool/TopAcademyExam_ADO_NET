using System.Windows;

namespace OlympiadWpfApp.Views;

public partial class ViewParticipantRowWindow : Window
{
    public ViewParticipantRowWindow(Window owner)
    {
        Owner = owner;
        InitializeComponent();
    }
}