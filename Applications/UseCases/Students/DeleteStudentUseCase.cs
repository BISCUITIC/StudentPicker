using Application.Services.Interfaces;
using Application.UseCases.Students.DTO;
using Application.UseCases.Students.Interfaces;

namespace Application.UseCases.Students;

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
