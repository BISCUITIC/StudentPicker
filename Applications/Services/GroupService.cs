using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class GroupService : IGroupService
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

    public Group? GetGroup(int groupId)
    {
        return _groupRepository.GetById(groupId);
    }

    public void AddGroup(Group group)
    {
        _groupRepository.Add(group);
    }

    public void UpdateGroup(Group group)
    {
        _groupRepository.Update(group);
    }
    public void DeleteGroup(int groupId)
    {
        _groupRepository.Remove(groupId);
    }
}
