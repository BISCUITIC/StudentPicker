using Presentation.Interfaces;
using Presentation.Services.Dialogs.DTO;
using Presentation.ViewModels.Dialogs;

namespace Presentation.Services.Dialogs.Abstractions;

public abstract class StudentDialogService : DialogService<StudentDialogResult,     
                                                           StudentDialogViewModel, 
                                                           IStudentDialog>
{
    protected override StudentDialogResult GetResult(StudentDialogViewModel context)
    {
        return new StudentDialogResult() { Name = context.Name, SecondName = context.SecondName };
    }
}
