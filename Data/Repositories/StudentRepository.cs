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

    public IReadOnlyCollection<Student> GetAllByGroupId(int groupId)
    {
        return _context.Students
                       .Where(student => student.GroupId == groupId)
                       .ToList();
    }

    public Student? GetById(int studentId)
    {
        return _context.Students
                       .FirstOrDefault(student => student.Id == studentId);
    }

    public void Add(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void Remove(int studentId)
    {
        _context.Students
                .Where(student => student.Id == studentId)
                .ExecuteDelete();
        _context.SaveChanges();
    }

    public void Update(Student updateStudent)
    {
        Student? student = _context.Students
                                   .FirstOrDefault(student => student.Id == updateStudent.Id);

        if (student is not null)
        {
            _context.Entry(student)
                    .CurrentValues
                    .SetValues(updateStudent);

            _context.SaveChanges();
        }
    }
}
