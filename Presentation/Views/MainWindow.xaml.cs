using Application.Services;
using System.Windows;

namespace Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(GroupProvider groupProvider)
    {
        InitializeComponent();
        string s = "";
        foreach(var i in groupProvider.GetGroups())
        {
            s += i.Id.ToString();
        }
        MessageBox.Show(s);
    }
}