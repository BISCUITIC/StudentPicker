using Application.UseCases.Students.DTO;

namespace Application.UseCases.Students.Interfaces;

public interface IUpdateStudentUseCase
{
    void Execute(UpdateStudentRequest updateRequest);
}
