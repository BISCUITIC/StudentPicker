using Application.UseCases.Students.DTO;
using Domain.Entities;

namespace Application.UseCases.Students.Interfaces;

public interface IAddStudentUseCase
{
    StudentDTO Execute(AddStudentRequest addRequest);
}
