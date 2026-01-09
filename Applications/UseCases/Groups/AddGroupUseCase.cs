using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Groups.DTO;
using Application.UseCases.Groups.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Groups;

public class AddGroupUseCase : IAddGroupUseCase
{
    private readonly IGroupService _groupService;

    public AddGroupUseCase(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public GroupDTO Execute(AddGroupRequest addRequest)
    {
        Group group = Mapper.ToGroup(addRequest);
        _groupService.AddGroup(group);
        return Mapper.ToGroupDTO(group);
    }
}
