using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services.Dialogs.Factories.Abstractions;

public abstract class StudentDialogFactory : DialogFactory<IStudentDialog, StudentModel>
{
    protected StudentDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }
}
