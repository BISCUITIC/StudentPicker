using Application.UseCases.Groups.DTO;
using Application.UseCases.Students.DTO;
using Domain.Entities;

namespace Application.Services;

internal static class Mapper
{
    public static Student ToStudent(AddStudentRequest studentRequest)
    {
        return new Student(name: studentRequest.Name, 
                           secondName: studentRequest.SecondName, 
                           groupId: studentRequest.GroupId);
    }

    public static StudentDTO ToStudentDTO(Student student)
    {
        return new StudentDTO(Id: student.Id, 
                              Name: student.Name, 
                              SecondName: student.SecondName);        
    }

    public static Group ToGroup(AddGroupRequest groupRequest)
    {
        return new Group(number: groupRequest.Number,
                         letter: groupRequest.Letter);
    }

    public static GroupDTO ToGroupDTO(Group group)
    {
        return new GroupDTO(Id: group.Id,
                            Number: group.Number,
                            Letter: group.Letter);
    }
}
