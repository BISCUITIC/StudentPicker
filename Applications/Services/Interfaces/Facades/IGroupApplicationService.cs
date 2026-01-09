using Application.UseCases.Groups.DTO;

namespace Application.Services.Interfaces.Facades;

public interface IGroupApplicationService
{
    IReadOnlyCollection<GroupDTO> Load();
    GroupDTO Add(AddGroupRequest request);
    void Delete(DeleteGroupRequest request);
    void Update(UpdateGroupRequest request);
}
