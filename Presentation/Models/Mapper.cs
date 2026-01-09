using Application.UseCases.Students.DTO;
using Presentation.Services.Dialogs.DTO;
using Presentation.ViewModels.Students;

namespace Presentation.Models;

internal static class Mapper
{
    public static UpdateStudentRequest ToUpdateStudentRequest(StudentDialogResult dialogResult,
                                                              int studentId)
    {
        return new UpdateStudentRequest(Id: studentId,
                                        Name: dialogResult.Name,
                                        SecondName: dialogResult.SecondName);
    }

    public static DeleteStudentRequest ToDeleteStudentRequest(int studentId)
    {
        return new DeleteStudentRequest(Id: studentId);
    }

    public static AddStudentRequest ToAddStudentRequest(StudentDialogResult dialogResult,
                                                        int groupId)
    {
        return new AddStudentRequest(Name: dialogResult.Name,
                                     SecondName: dialogResult.SecondName,
                                     GroupId: groupId);
    }

    public static PickStudentRequest ToPickStudentRequest(IReadOnlyCollection<StudentItemViewModel> collection)
    {
        List<StudentPickInfo> data = collection.Select(data => new StudentPickInfo(Id: data.Student.Id,
                                                                                   IsExcluded: data.IsExcluded))
                                               .ToList();

        return new PickStudentRequest(Items: data);

    }
}
