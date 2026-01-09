using Application.UseCases.Student.DTO;
using Domain.Entities;
using Presentation.Services.Dialogs.DTO;

namespace Presentation.Models;

public static class StudentModelMapper
{
    public static void UpdateModelFromDialogResult(StudentDialogResult result, StudentModel model)
    {
        model.Name = result.Name;
        model.SecondName = result.SecondName;
    }

    public static void UpdateModelFromDialogResult(GroupDialogResult result, GroupModel model)
    {
        model.Number = result.Number;
        model.Letter = result.Letter;
    }

    public static StudentModel ToModel(StudentDTO studentDTO)
    {
        return new StudentModel(studentDTO);
    }

    public static Group ToDomain(GroupDialogResult result)
    {
        return new Group(result.Number, result.Letter);
    }

    public static Group ToDomain(GroupModel model)
    {
        return new Group(model.Id, model.Number, model.Letter);
    }
}
