using Application.UseCases.Groups.DTO;

namespace Application.UseCases.Groups.Interfaces;

public interface IUpdateGroupUseCase
{
    void Execute(UpdateGroupRequest updateRequest);
}
