using Application.UseCases.DTO;
using Domain.Entities;

namespace Application.UseCases.Interfaces;

public interface IAddStudentUseCase
{
    Student Execute(AddStudentRequest addRequest);
}
