using Presentation.Models;
using Presentation.Views;

namespace Presentation.Services.Factories;

public class AddStudentDialogFactory : StudentDialogFactory
{
    public AddStudentDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override void ConfigureDialog(StudentDialog dialog, StudentModel? mdoel)
    {
        dialog.Title = "Add student";
    }
}
