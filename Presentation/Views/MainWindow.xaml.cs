using Presentation.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly WindowContext _windowContext;

    public MainWindow(WindowContext windowContext)
    {
        InitializeComponent();
        
        _windowContext = windowContext;
        DataContext = _windowContext;        
    }

    public void LoadGroup_Executed(object sender, ExecutedRoutedEventArgs e)
    {     
        _windowContext.LoadGroup_Executed(sender, e);
    }
}