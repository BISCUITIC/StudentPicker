using Domain.Entities;
using Presentation.Services.DTO;

namespace Presentation.Models;

public static class StudentMapper
{
    public static void UpdateDomainFromModel(StudentModel model, Student domain)
    {
        domain.UpdateName(model.Name);
        domain.UpdateSecondName(model.SecondName);
    }

    public static Student ToDomain(int groupId, AddStudentResult result)
    {
        return new Student(result.Name, result.SecondName, groupId);
    }
}
