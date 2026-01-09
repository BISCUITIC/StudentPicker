using Application.UseCases.Student.DTO;

namespace Application.UseCases.Student.Interfaces;

public interface IDeleteStudentUseCase
{
    void Execute(DeleteStudentRequest deleteRequest);
}
