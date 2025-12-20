using Presentation.Models;
using Presentation.Services.DTO;

namespace Presentation.Services.Interfaces;

public interface IUpdateStudentDialogService
{
    StudentDialogResult? ShowUpdateStudentDialog(StudentModel studentModel);
}
