using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IGroupService
{
    IReadOnlyCollection<Group> GetAllGroups();
    Group GetGroup(int groupId);
    void AddGroup(Group group);
    void UpdateGroup(Group group);
    void DeleteGroup(int studentId);
}
