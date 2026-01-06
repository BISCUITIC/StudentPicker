using Presentation.Models;
using Presentation.Services.Dialogs.DTO;

namespace Presentation.Services.Dialogs.Interfaces;

public interface IUpdateStudentDialogService
{
    StudentDialogResult? ShowUpdateStudentDialog(StudentModel studentModel);
}
