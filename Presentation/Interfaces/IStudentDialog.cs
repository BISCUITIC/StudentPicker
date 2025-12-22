using Presentation.ViewModels.Dialogs;

namespace Presentation.Interfaces;

public interface IStudentDialog : IDialog
{
    StudentDialogViewModel Context { get; }
}
