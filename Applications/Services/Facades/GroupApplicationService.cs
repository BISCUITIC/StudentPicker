using Application.Services.Interfaces.Facades;
using Application.UseCases.Groups.DTO;
using Application.UseCases.Groups.Interfaces;

namespace Application.Services.Facades;

public class GroupApplicationService : IGroupApplicationService
{
    private readonly ILoadGroupsUseCase _loadGroupsUseCase;
    private readonly IAddGroupUseCase _addGroupUseCase;
    private readonly IDeleteGroupUseCase _deleteGroupUseCase;
    private readonly IUpdateGroupUseCase _updateGroupUseCase;

    public GroupApplicationService(ILoadGroupsUseCase loadGroupsUseCase,
                                   IAddGroupUseCase addGroupUseCase,
                                   IDeleteGroupUseCase deleteGroupUseCase,
                                   IUpdateGroupUseCase updateGroupUseCase)
    {

        _loadGroupsUseCase = loadGroupsUseCase;
        _updateGroupUseCase = updateGroupUseCase;
        _deleteGroupUseCase = deleteGroupUseCase;
        _addGroupUseCase = addGroupUseCase;
    }

    public IReadOnlyCollection<GroupDTO> Load()
    => _loadGroupsUseCase.Execute();

    public GroupDTO Add(AddGroupRequest request)
    => _addGroupUseCase.Execute(request);

    public void Delete(DeleteGroupRequest request)
    => _deleteGroupUseCase.Execute(request);

    public void Update(UpdateGroupRequest request)
    => _updateGroupUseCase.Execute(request);
}
