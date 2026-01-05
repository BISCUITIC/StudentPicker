using Application.UseCases.DTO;
using Domain.Entities;

namespace Application.UseCases.Interfaces;

public interface IAddStudentUseCase
{
    StudentDTO Execute(AddStudentRequest addRequest);
}
