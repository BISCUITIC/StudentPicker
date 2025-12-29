using Application.Interfaces;
using Application.Services.Interfaces;
using Application.UseCases.DTO;
using Application.UseCases.Interfaces;

namespace Application.UseCases;

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
