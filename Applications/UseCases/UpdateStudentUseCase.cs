using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.DTO;
using Application.UseCases.Interfaces;

namespace Application.UseCases;

public class UpdateStudentUseCase : IUpdateStudentUseCase
{
    private readonly IStudentService _studentService;

    public UpdateStudentUseCase(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public void Execute(UpdateStudentRequest updateRequest)
    {
        _studentService.UpdateStudent(Mapper.ToStudent(updateRequest));
    }
}
