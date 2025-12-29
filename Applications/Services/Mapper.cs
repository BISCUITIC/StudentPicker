using Application.UseCases.DTO;
using Domain.Entities;

namespace Application.Services;

internal static class Mapper
{
    public static Student ToStudent(UpdateStudentRequest studentRequest)
    {
        return new Student(studentRequest.Id, studentRequest.Name, studentRequest.SecondName, studentRequest.GroupId);
    }

    public static Student ToStudent(AddStudentRequest studentRequest)
    {
        return new Student(studentRequest.Name, studentRequest.SecondName, studentRequest.GroupId);
    }
}
