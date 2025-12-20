using Presentation.Services.DTO;

namespace Presentation.Services.Interfaces;

public interface IAddStudentDialogService
{
    StudentDialogResult? ShowAddStudentDialog();
}
