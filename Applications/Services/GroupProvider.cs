using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class GroupProvider
{
    private readonly IGroupRepository _groupRepository;

    public GroupProvider(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public IReadOnlyCollection<Group> GetGroups()
    {
        return _groupRepository.GetAll();
    }
}
