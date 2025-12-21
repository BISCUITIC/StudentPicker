using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services.DTO;
using Presentation.Services.Factories;
using Presentation.Services.Interfaces;
using Presentation.ViewModels;

namespace Presentation.Services.Dialogs;

public class UpdateStudentDialogService : StudentDialogService, IUpdateStudentDialogService
{
    private readonly UpdateStudentDialogFactory _dialogFactory;

    public UpdateStudentDialogService(UpdateStudentDialogFactory dialogFactory)
    {
        _dialogFactory = dialogFactory;
    }

    public StudentDialogResult? ShowUpdateStudentDialog(StudentModel studentModel)
    {
        IStudentDialog dialog = _dialogFactory.CreateDialog(studentModel);
        StudentDialogViewModel context = dialog.Context;

        if (IsDialogConfirmedAndValid(dialog, context))
        {
            return GetResult(context);
        }
        else
        {
            return null;
        }
    }
}
