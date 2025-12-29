using Application.Services.Interfaces;
using Application.UseCases.Interfaces;
using Domain.Entities;

namespace Application.UseCases;

public class LoadStudentsUseCase : ILoadStudentsUseCase
{
    private readonly IStudentService _studentService;

    public LoadStudentsUseCase(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public IReadOnlyCollection<Student> Execute(int groupId)
    {
        return _studentService.GetStudents(groupId);
    }
}
