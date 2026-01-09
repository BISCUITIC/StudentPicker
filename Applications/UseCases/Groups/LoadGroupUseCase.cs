using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Groups.DTO;
using Application.UseCases.Groups.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Groups;

public class LoadGroupUseCase : ILoadGroupsUseCase
{
    private readonly IGroupService _groupService;

    public LoadGroupUseCase(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public IReadOnlyCollection<GroupDTO> Execute()
    {
        IReadOnlyCollection<Group> groups = _groupService.GetAllGroups();
        return groups.Select(Mapper.ToGroupDTO).ToList();
    }
}
