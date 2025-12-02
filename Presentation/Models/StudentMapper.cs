using Domain.Entities;

namespace Presentation.Models;

public static class StudentMapper
{
    public static Student ToDomain(StudentModel model, Student domain)
    {
        domain.UpdateName(model.Name);
        domain.UpdateSecondName(model.SecondName);
        return domain;
    }
}
