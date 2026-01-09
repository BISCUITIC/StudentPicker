using Application.UseCases.Students.DTO;

namespace Application.UseCases.Students.Interfaces;

public interface IPickStudentUseCase
{
    int? Execute(PickStudentRequest pickRequest);
}
