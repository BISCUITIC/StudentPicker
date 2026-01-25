using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Students.DTO;
using Application.UseCases.Students.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Students;

public class AddStudentUseCase : IAddStudentUseCase
{
    private readonly IStudentService _studentService;

    public AddStudentUseCase(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public StudentDTO Execute(AddStudentRequest addRequest)
    {
        Student student = Mapper.ToStudent(addRequest);
        _studentService.AddStudent(student);
        _studentService.SaveChanges();
        return Mapper.ToStudentDTO(student);
    }
}
