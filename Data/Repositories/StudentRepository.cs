using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationContext _context;

    public StudentRepository(ApplicationContext applicationContext)
    {
        _context = applicationContext;
    }

    public List<Student> GetAllByGroupId(int groupId)
    {
        return _context.Students
                       .Where(student => student.GroupId == groupId)
                       .ToList();
    }

    public Student GetById(int studentId)
    {
        return _context.Students
                       .First(student => student.Id == studentId);
    }

    public void Add(Student student)
    {
        _context.Add(student);
        _context.SaveChanges();
    }

    public void Remove(Student student)
    {
        _context.Remove(student);
        _context.SaveChanges();
    }

    public void Update(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
    }
}
