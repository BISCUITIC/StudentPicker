using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class StudentProvider
{
    private readonly IStudentRepository _studentRepository;

    public StudentProvider(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public IReadOnlyCollection<Student> GetStudents(Group group)
    {
        return _studentRepository.GetAllByGroup(group);
    }
}
