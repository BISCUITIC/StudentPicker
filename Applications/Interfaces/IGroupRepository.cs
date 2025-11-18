using Domain.Entities;

namespace Application.Interfaces;

public interface IGroupRepository
{
    IReadOnlyCollection<Group> GetAll();
    Group GetById(int groupId);
}
