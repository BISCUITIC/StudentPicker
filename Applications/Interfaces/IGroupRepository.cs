using Domain.Entities;

namespace Application.Interfaces;

public interface IGroupRepository
{
    IReadOnlyCollection<Group> GetAll();
    Group GetById(int id);
    void Add(Group student);
    bool Exist(int number, char letter);
    void Remove(int id);
    void SaveChanges();
}
