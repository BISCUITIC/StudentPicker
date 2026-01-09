using Application.UseCases.Groups.DTO;

namespace Application.UseCases.Groups.Interfaces;

public interface IAddGroupUseCase
{
    GroupDTO Execute(AddGroupRequest addRequest);
}
