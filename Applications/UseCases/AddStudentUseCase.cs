using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.DTO;
using Application.UseCases.Interfaces;
using Domain.Entities;

namespace Application.UseCases;

public class AddStudentUseCase : IAddStudentUseCase
{
    private readonly IStudentService _studentService;

    public AddStudentUseCase(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public Student Execute(AddStudentRequest addRequest)
    {
        Student student = Mapper.ToStudent(addRequest);
        _studentService.AddStudent(student);
        return student;
    }
}
