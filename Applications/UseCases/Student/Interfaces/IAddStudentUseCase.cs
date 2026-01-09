using Application.UseCases.Student.DTO;
using Domain.Entities;

namespace Application.UseCases.Student.Interfaces;

public interface IAddStudentUseCase
{
    StudentDTO Execute(AddStudentRequest addRequest);
}
