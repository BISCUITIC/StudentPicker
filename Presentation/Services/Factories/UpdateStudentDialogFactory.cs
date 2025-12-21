using Presentation.Models;
using Presentation.Views;

namespace Presentation.Services.Factories;

public class UpdateStudentDialogFactory : StudentDialogFactory
{
    public UpdateStudentDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override void ConfigureDialog(StudentDialog dialog, StudentModel? model)
    {
        dialog.Title = "Update student";
        dialog.Context.Name = model?.Name;
        dialog.Context.SecondName = model?.SecondName;
    }
}
