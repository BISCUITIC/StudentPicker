using Presentation.Interfaces;
using Presentation.Services.DTO;
using Presentation.ViewModels.Dialogs;

namespace Presentation.Services.Dialogs.Abstractions;

public abstract class StudentDialogService : DialogService<StudentDialogResult, StudentDialogViewModel, IStudentDialog>
{
    protected override StudentDialogResult GetResult(StudentDialogViewModel context)
    {
        return new StudentDialogResult() { Name = context.Name, SecondName = context.SecondName };
    }

    protected override bool IsDialogConfirmedAndValid(IStudentDialog dialog, StudentDialogViewModel context)
    {
        return dialog.ShowDialog() == true && DialogNotEmpty(context);
    }

    private bool DialogNotEmpty(StudentDialogViewModel context)
    {
        return !string.IsNullOrWhiteSpace(context.Name) &&
               !string.IsNullOrWhiteSpace(context.SecondName);
    }
}
