using Presentation.Services.DTO;
using Presentation.Services.Factories;
using Presentation.Services.Interfaces;
using Presentation.ViewModels;
using Presentation.Views;

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
        StudentDialog dialog = _dialogFactory.CreateDialog();
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
