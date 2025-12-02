using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class GroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public IReadOnlyCollection<Group> GetAllGroups()
    {
        return _groupRepository.GetAll();
    }
}
