using System.Windows.Input;

namespace Presentation.Commands;

internal class WindowCommands
{
    static WindowCommands()
    {
        LoadGroup = new RoutedCommand("LoadGroup", typeof(MainWindow));
    }
    public static RoutedCommand LoadGroup { get; set; }
}
