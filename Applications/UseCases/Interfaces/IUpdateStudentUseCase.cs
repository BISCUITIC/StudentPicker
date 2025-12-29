using Application.UseCases.DTO;

namespace Application.UseCases.Interfaces;

public interface IUpdateStudentUseCase
{
    void Execute(UpdateStudentRequest updateRequest);
}
