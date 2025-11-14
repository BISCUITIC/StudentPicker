using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class IncorrectGroupData : Exception
{
    public IncorrectGroupData(string? message) : base(message) { }
}

public class StudentProvider : IStudentProvider
{
    private readonly ApplicationContext _context;

    public StudentProvider(ApplicationContext applicationContext)
    {
        _context = applicationContext;
    }

    public List<Student> GetStudents(int groupNumber, char groupLetter)
    {
        return _context.Students
                       .Include(student => student.StudyGroup)
                       .Where(student => student.StudyGroup.Number == groupNumber &&
                                         student.StudyGroup.Letter == groupLetter)
                       .ToList();
    }
}
