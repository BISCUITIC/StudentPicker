using Presentation.Models;
using Presentation.Services.DTO;
using Presentation.Services.Interfaces;
using Presentation.ViewModels;
using Presentation.Views;

namespace Presentation.Services;

public class UpdateStudentDialogService : StudentDialogService, IUpdateStudentDialogService
{
    public UpdateStudentDialogService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public StudentDialogResult? ShowUpdateStudentDialog(StudentModel studentModel)
    {
        StudentDialog dialog = CreateDialog();
        StudentDialogViewModel context = dialog.Context;

        dialog.Title = "Update student";
        context.Name = studentModel.Name;
        context.SecondName = studentModel.SecondName;

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
