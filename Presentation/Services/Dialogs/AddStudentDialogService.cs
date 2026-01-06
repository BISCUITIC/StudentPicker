using Presentation.Interfaces;
using Presentation.Services.Dialogs.Abstractions;
using Presentation.Services.Dialogs.DTO;
using Presentation.Services.Dialogs.Interfaces;
using Presentation.Services.Factories;

namespace Presentation.Services.Dialogs;

public class AddStudentDialogService : StudentDialogService, IAddStudentDialogService
{
    private readonly AddStudentDialogFactory _dialogFactory;

    public AddStudentDialogService(AddStudentDialogFactory dialogFactory)
    {
        _dialogFactory = dialogFactory;
    }

    public StudentDialogResult? ShowAddStudentDialog()
    {
        IStudentDialog dialog = _dialogFactory.CreateDialog();
        return ShowInternal(dialog, dialog.Context);
    }
}
