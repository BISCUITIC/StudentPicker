using Application.Services.Interfaces;
using Application.UseCases.Groups.DTO;
using Application.UseCases.Groups.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Groups;

public class UpdateGroupUseCase : IUpdateGroupUseCase
{
    private readonly IGroupService _groupService;

    public UpdateGroupUseCase(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public void Execute(UpdateGroupRequest updateRequest)
    {
        Group group = _groupService.GetGroup(updateRequest.Id);

        group.UpdateNumber(updateRequest.Number);
        group.UpdateLetter(updateRequest.Letter);

        _groupService.SaveChanges();
    }
}
