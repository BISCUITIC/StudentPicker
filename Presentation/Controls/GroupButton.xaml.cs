using System.Windows.Controls;
using Domain.Entities;

namespace Presentation.Controls;

/// <summary>
/// Логика взаимодействия для GroupButton.xaml
/// </summary>
public partial class GroupButton : Button
{
    private readonly Group _group;
    public Group Group{ init => _group = value; get => _group; }

    public GroupButton()
    {
        InitializeComponent();
    }    

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}
