using Application.UseCases.DTO;

namespace Application.UseCases.Interfaces;

public interface IDeleteStudentUseCase
{
    void Execute(DeleteStudentRequest deleteRequest);
}
