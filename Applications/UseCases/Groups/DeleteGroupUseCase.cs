using Application.Exceptions;
using Application.Services.Interfaces;
using Application.UseCases.Groups.DTO;
using Application.UseCases.Groups.Interfaces;

namespace Application.UseCases.Groups;

public class DeleteGroupUseCase : IDeleteGroupUseCase
{
    private readonly IGroupService _groupService;

    public DeleteGroupUseCase(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public void Execute(DeleteGroupRequest deleteRequest)
    {
        if (!_groupService.Exist(deleteRequest.Id))        
            throw new GroupNotFoundException();
       
        _groupService.DeleteGroup(deleteRequest.Id);
    }
}
