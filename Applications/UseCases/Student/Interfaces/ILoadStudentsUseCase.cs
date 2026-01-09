using Application.UseCases.Student.DTO;

namespace Application.UseCases.Student.Interfaces;

public interface ILoadStudentsUseCase
{
    IReadOnlyCollection<StudentDTO> Execute(int groupId);
}
