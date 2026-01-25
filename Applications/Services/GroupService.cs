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

    public Group GetGroup(int id)
    {
        return _groupRepository.GetById(id);
    }

    public void AddGroup(Group group)
    {
        _groupRepository.Add(group);
    }

    public bool Exist(int number, char letter)
    {
        return _groupRepository.Exist(number, letter);
    }

    public bool Exist(int id)
    {
        return (_groupRepository.GetById(id) is null) ? false : true;
    }

    public void SaveChanges()
    {
        _groupRepository.SaveChanges();
    }

    public void DeleteGroup(int groupId)
    {
        _groupRepository.Remove(groupId);
    }
}
