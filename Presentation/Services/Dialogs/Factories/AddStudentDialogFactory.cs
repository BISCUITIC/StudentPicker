using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services.Dialogs.Factories.Abstractions;

namespace Presentation.Services.Factories;

public class AddStudentDialogFactory : StudentDialogFactory
{
    public AddStudentDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override void ConfigureDialog(IStudentDialog dialog, StudentModel? mdoel)
    {
        dialog.Title = "Add student";
    }
}
