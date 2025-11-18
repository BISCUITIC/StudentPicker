using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationContext _context;

    public StudentRepository(ApplicationContext applicationContext)
    {
        _context = applicationContext;
    }

    public List<Student> GetByGroup(Group group)
    {
        return _context.Students
                       .Include(student => student.StudyGroup)
                       .Where(student => student.StudyGroup.Number == group.Number &&
                                         student.StudyGroup.Letter == group.Letter)
                       .ToList();
    }
}
