using Presentation.ViewModels;
using System.Windows;

namespace Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel windowContext)
    {
        InitializeComponent();

        DataContext = windowContext;
    }

    private void RandomButton_Click(object sender, RoutedEventArgs e)
    {

    }
}