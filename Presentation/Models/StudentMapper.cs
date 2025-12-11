using Domain.Entities;
using System.Windows;

namespace Presentation.Models;

public static class StudentMapper
{
    public static void TryParseModelToDomain(StudentModel model, Student domain)
    {       
        domain.UpdateName(model.Name);
        domain.UpdateSecondName(model.SecondName);                
    }
}
