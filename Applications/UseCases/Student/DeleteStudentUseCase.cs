using Application.Interfaces;
using Application.Services.Interfaces;
using Application.UseCases.Student.DTO;
using Application.UseCases.Student.Interfaces;

namespace Application.UseCases.Student;

public class DeleteStudentUseCase : IDeleteStudentUseCase
{
    private readonly IStudentService _studentService;

    public DeleteStudentUseCase(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public void Execute(DeleteStudentRequest deleteRequest)
    {
        _studentService.DeleteStudent(deleteRequest.Id);
    }
}
