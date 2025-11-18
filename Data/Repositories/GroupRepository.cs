using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class GroupDataExseption : Exception
{
    public GroupDataExseption(string? message) : base(message) { }
}

public class GroupRepository : IGroupRepository
{
    private readonly ApplicationContext _context;

    public GroupRepository(ApplicationContext applicationContext)
    {
        _context = applicationContext;
    }

    public Group Get(int groupNumber, char groupLetter)
    {
        return _context.Groups
                       .FirstOrDefault(group => group.Number == groupNumber &&
                                                group.Letter == groupLetter)
                       ?? throw new GroupDataExseption($"No such group {groupNumber} \"{groupLetter}\"");
    }
}
