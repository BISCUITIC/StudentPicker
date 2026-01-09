using Application.UseCases.Students.DTO;

namespace Application.UseCases.Students.Interfaces;

public interface IDeleteStudentUseCase
{
    void Execute(DeleteStudentRequest deleteRequest);
}
