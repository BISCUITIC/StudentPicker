using Presentation.Interfaces;
using Presentation.Services.DTO;
using Presentation.Services.Factories;
using Presentation.Services.Interfaces;
using Presentation.ViewModels;

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
