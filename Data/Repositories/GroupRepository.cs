using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Exceptions;

namespace Infrastructure.Repositories;



public class GroupRepository : IGroupRepository
{
    private readonly ApplicationContext _context;

    public GroupRepository(ApplicationContext applicationContext)
    {
        _context = applicationContext;
    }

    public IReadOnlyCollection<Group> GetAll()
    {
        return _context.Groups.ToList();
    }

    public Group GetById(int groupId)
    {
        return _context.Groups
                       .FirstOrDefault(group => group.Id == groupId)
                       ?? throw new GroupNotFoundException($"No group with such id {groupId}");
    }
}
