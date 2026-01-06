using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IStudentService
{
    IReadOnlyCollection<Student> GetStudents(int groupId);
    Student GetStudent(int studentId);
    void AddStudent(Student student);
    void DeleteStudent(int studentId);
    void SaveChanges();
}
