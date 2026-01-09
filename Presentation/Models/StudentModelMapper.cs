using Application.UseCases.Students.DTO;
using Presentation.Services.Dialogs.DTO;

namespace Presentation.Models;

public static class StudentModelMapper
{
    public static void UpdateModelFromDialogResult(StudentDialogResult result, StudentModel model)
    {
        model.Name = result.Name;
        model.SecondName = result.SecondName;
    }

    public static StudentModel ToModel(StudentDTO studentDTO)
    {
        return new StudentModel(studentDTO);
    }
}
