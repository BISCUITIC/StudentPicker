using Application.UseCases.DTO;
using Presentation.Models;
using Presentation.Services.DTO;
using Presentation.ViewModels.Students;

namespace Presentation.Services;

internal static class Mapper
{
    public static UpdateStudentRequest ToUpdateStudentRequest(StudentDialogResult dialogResult, int studentId, int groupId)
    {
        return new UpdateStudentRequest()
        {
            Id = studentId,
            Name = dialogResult.Name,
            SecondName = dialogResult.SecondName,
            GroupId = groupId                    
        };
    }

    public static DeleteStudentRequest ToDeleteStudentRequest(int studentId)
    {
        return new DeleteStudentRequest()
        {
            Id = studentId,         
        };
    }

    public static AddStudentRequest ToAddStudentRequest(StudentDialogResult dialogResult, int groupId)
    {
        return new AddStudentRequest()
        { 
            Name = dialogResult.Name,
            SecondName = dialogResult.SecondName,
            GroupId = groupId
        };
    }

    public static PickStudentRequest ToPickStudentRequest(IReadOnlyCollection<StudentItemViewModel> collection)
    {
        var data = collection.Select(data => 
                                     new PickData
                                     { 
                                         Id = data.Student.Id, 
                                         IsExcluded = data.IsExcluded
                                     })
                             .ToList();

        return new PickStudentRequest()
        {
            Data = data
        };
    }
}
