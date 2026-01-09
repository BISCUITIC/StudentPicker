using Application.UseCases.Groups.DTO;

namespace Application.UseCases.Groups.Interfaces;

public interface ILoadGroupsUseCase
{
    IReadOnlyCollection<GroupDTO> Execute();
}
