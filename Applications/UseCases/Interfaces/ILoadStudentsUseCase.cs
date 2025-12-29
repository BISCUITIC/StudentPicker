using Domain.Entities;

namespace Application.UseCases.Interfaces;

public interface ILoadStudentsUseCase
{
    IReadOnlyCollection<Student> Execute(int groupId);
}
