using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class StudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public IReadOnlyCollection<Student> GetStudents(int groupId)
    {
        return _studentRepository.GetAllByGroupId(groupId);
    }
    public Student GetStudent(int studentId)
    {
        return _studentRepository.GetById(studentId);
    }
    public void UpdateStudent(Student student)
    {
        _studentRepository.Update(student);
    }
}
