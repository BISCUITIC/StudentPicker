using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public Group? GetById(int groupId)
    {
        return _context.Groups
                       .FirstOrDefault(group => group.Id == groupId);
    }
    public void Add(Group group)
    {
        _context.Groups.Add(group);
        _context.SaveChanges();
    }

    public void Remove(int groupId)
    {
        _context.Groups
                .Where(group => group.Id == groupId)
                .ExecuteDelete();
        _context.SaveChanges();
    }

    public void Update(Group updateGroup)
    {
        Group? group = _context.Groups
                               .FirstOrDefault(group => group.Id == updateGroup.Id);

        if (group is not null)
        {
            _context.Entry(group)
                    .CurrentValues
                    .SetValues(updateGroup);

            _context.SaveChanges();
        }
    }
}
