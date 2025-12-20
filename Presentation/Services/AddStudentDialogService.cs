using Presentation.Services.DTO;
using Presentation.Services.Interfaces;
using Presentation.ViewModels;
using Presentation.Views;

namespace Presentation.Services;

public class AddStudentDialogService : StudentDialogService, IAddStudentDialogService
{
    public AddStudentDialogService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public StudentDialogResult? ShowAddStudentDialog()
    {
        StudentDialog dialog = CreateDialog();
        StudentDialogViewModel context = dialog.Context;
        dialog.Title = "Add student";

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
