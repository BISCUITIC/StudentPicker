using Application.UseCases.DTO;

namespace Application.UseCases.Interfaces;

public interface IPickStudentUseCase
{
    int? Execute(PickStudentRequest pickRequest);
}
