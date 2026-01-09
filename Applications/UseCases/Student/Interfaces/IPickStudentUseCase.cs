using Application.UseCases.Student.DTO;

namespace Application.UseCases.Student.Interfaces;

public interface IPickStudentUseCase
{
    int? Execute(PickStudentRequest pickRequest);
}
