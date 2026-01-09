using Application.UseCases.Students.DTO;

namespace Application.UseCases.Students.Interfaces;

public interface ILoadStudentsUseCase
{
    IReadOnlyCollection<StudentDTO> Execute(int groupId);
}
