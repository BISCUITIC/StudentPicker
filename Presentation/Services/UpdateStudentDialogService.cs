using Presentation.Services.DTO;
using Presentation.Services.Interfaces;

namespace Presentation.Services;

public class UpdateStudentDialogService : StudentDialogService, IUpdateStudentDialogService
{
    public UpdateStudentDialogService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public StudentDialogResult? ShowUpdateStudentDialog()
    {
        //CreateDialog();
        if (IsDialogConfirmedAndValid())
        {
            return GetResult();
        }
        else
        {
            return null;
        }
    }
}
