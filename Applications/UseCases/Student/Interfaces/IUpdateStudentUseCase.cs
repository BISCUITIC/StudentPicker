using Application.UseCases.Student.DTO;

namespace Application.UseCases.Student.Interfaces;

public interface IUpdateStudentUseCase
{
    void Execute(UpdateStudentRequest updateRequest);
}
