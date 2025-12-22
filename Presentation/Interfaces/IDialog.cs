using System.Windows;

namespace Presentation.Interfaces;

public interface IDialog
{
    string Title { get; set; }
    Window Owner { get; set; }
    WindowStartupLocation WindowStartupLocation { get; set; }
    bool? ShowDialog();
}
    