using Presentation.Services.DTO;

namespace Presentation.Services.Interfaces;

internal interface IUpdateStudentDialogService
{
    StudentDialogResult? ShowUpdateStudentDialog();
}
