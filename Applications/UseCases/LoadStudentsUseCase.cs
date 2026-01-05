using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.DTO;
using Application.UseCases.Interfaces;
using Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Application.UseCases;

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
