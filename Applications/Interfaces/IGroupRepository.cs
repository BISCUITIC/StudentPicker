using Domain.Entities;

namespace Application.Interfaces;

public interface IGroupRepository
{
    IReadOnlyCollection<Group> GetAll();
    Group? GetById(int groupId);
    void Add(Group student);
    void Remove(int id);
    void Update(Group student);
}
