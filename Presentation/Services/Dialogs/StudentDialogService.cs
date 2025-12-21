using Presentation.Interfaces;
using Presentation.Services.DTO;
using Presentation.ViewModels;

namespace Presentation.Services.Dialogs;

public abstract class StudentDialogService
{
    protected StudentDialogResult GetResult(StudentDialogViewModel context)
    {
        return new StudentDialogResult() { Name = context.Name, SecondName = context.SecondName };
    }

    protected bool IsDialogConfirmedAndValid(IStudentDialog dialog, StudentDialogViewModel context)
    {
        return dialog.ShowDialog() == true && DialogNotEmpty(context);
    }

    private bool DialogNotEmpty(StudentDialogViewModel context)
    {
        return !string.IsNullOrWhiteSpace(context.Name) &&
               !string.IsNullOrWhiteSpace(context.SecondName);
    }
}
