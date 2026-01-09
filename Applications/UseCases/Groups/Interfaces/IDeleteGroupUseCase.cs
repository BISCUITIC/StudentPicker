using Application.UseCases.Groups.DTO;

namespace Application.UseCases.Groups.Interfaces;

public interface IDeleteGroupUseCase
{
    void Execute(DeleteGroupRequest deleteRequest);
}
