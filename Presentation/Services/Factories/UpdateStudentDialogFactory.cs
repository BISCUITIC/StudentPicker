using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services.Factories;

public class UpdateStudentDialogFactory : StudentDialogFactory
{
    public UpdateStudentDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override void ConfigureDialog(IStudentDialog dialog, StudentModel? model)
    {
        dialog.Title = "Update student";
        dialog.Context.Name = model?.Name;
        dialog.Context.SecondName = model?.SecondName;
    }
}
