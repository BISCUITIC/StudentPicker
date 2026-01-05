using Application.UseCases.DTO;

namespace Application.UseCases.Interfaces;

public interface ILoadStudentsUseCase
{
    IReadOnlyCollection<StudentDTO> Execute(int groupId);
}
