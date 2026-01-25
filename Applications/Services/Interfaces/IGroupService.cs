using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IGroupService
{
    IReadOnlyCollection<Group> GetAllGroups();
    Group GetGroup(int groupId);
    void AddGroup(Group group);
    bool Exist(int number, char letter);
    bool Exist(int id);
    void DeleteGroup(int studentId);
    void SaveChanges();
}
