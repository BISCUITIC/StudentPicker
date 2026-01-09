using Application.UseCases.Students.DTO;

namespace Application.UseCases.Students.Interfaces;

public interface IAddStudentUseCase
{
    StudentDTO Execute(AddStudentRequest addRequest);
}
