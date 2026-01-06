using Application.Services.Interfaces;
using Application.UseCases.DTO;
using Application.UseCases.Interfaces;
using Domain.Entities;

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
        Student student = _studentService.GetStudent(updateRequest.Id);
        
        student.UpdateName(updateRequest.Name);
        student.UpdateSecondName(updateRequest.SecondName);

        _studentService.SaveChanges();
    }
}
