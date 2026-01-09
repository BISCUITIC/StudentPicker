using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Student.DTO;
using Application.UseCases.Student.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Student;

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
        return Mapper.ToStudentDTO(student);        
    }
}
