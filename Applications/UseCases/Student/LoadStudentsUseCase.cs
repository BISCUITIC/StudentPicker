using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Student.DTO;
using Application.UseCases.Student.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Student;

public class LoadStudentsUseCase : ILoadStudentsUseCase
{
    private readonly IStudentService _studentService;

    public LoadStudentsUseCase(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public IReadOnlyCollection<StudentDTO> Execute(int groupId)
    {
        IReadOnlyCollection<Student> students = _studentService.GetStudents(groupId);
        return students.Select(student => Mapper.ToStudentDTO(student)).ToList();
    }
}
