using Presentation.ViewModels;
using System.Windows;

namespace Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(WindowContext windowContext)
    {
        InitializeComponent();
        
        DataContext = windowContext;        
    }
}