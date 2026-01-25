using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

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
    }

    public bool Exist(int number, char letter)
    {
        Group? group = _context.Groups
                               .FirstOrDefault(group => group.Number == number && 
                                                        group.Letter == letter);
        
        return (group is null) ? false : true;
    }

    public void Remove(int groupId)
    {
        _context.Groups
                .Where(group => group.Id == groupId)
                .ExecuteDelete();
        _context.SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
