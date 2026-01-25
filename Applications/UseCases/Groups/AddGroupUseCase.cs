using Application.Services;
using Application.Exceptions;
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

        if(_groupService.Exist(addRequest.Number, addRequest.Letter))                
            throw new GroupAlreadyExistException(addRequest.Number, addRequest.Letter);
        
        _groupService.AddGroup(group);        
        return Mapper.ToGroupDTO(group);
    }
}
