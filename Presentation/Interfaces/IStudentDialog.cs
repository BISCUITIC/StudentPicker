using Presentation.ViewModels;
using System.Windows;

namespace Presentation.Interfaces;

public interface IStudentDialog
{
    string Title { get; set; }
    StudentDialogViewModel Context { get; }
    Window Owner {  get; set; }
    WindowStartupLocation WindowStartupLocation { get; set; }
    bool? ShowDialog();
}
