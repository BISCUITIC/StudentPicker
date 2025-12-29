using Presentation.Models;
using Presentation.Services.DTO;

namespace Presentation.Services.Dialogs.Interfaces;

public interface IUpdateStudentDialogService
{
    StudentDialogResult? ShowUpdateStudentDialog(StudentModel studentModel);
}
