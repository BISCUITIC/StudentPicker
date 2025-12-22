using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services.Dialogs.Abstractions;
using Presentation.Services.DTO;
using Presentation.Services.Factories;
using Presentation.Services.Interfaces;

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
        return ShowInternal(dialog, dialog.Context);
    }
}
