using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services.Factories;

public class AddStudentDialogFactory : StudentDialogFactory
{
    public AddStudentDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override void ConfigureDialog(IStudentDialog dialog, StudentModel? mdoel)
    {
        dialog.Title = "Add student";
    }
}
