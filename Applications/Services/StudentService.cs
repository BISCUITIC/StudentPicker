using Application.Interfaces;
using Domain.Entities;
using Application.Services.Interfaces;

namespace Application.Services;

public class StudentService : IStudentService
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

    public void AddStudent(Student student)
    {
        _studentRepository.Add(student);        
    }

    public void UpdateStudent(Student student)
    {
        _studentRepository.Update(student);
    }
    public void DeleteStudent(Student student)
    {
        _studentRepository.Remove(student);
    }
}
