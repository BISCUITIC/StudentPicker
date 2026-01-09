using Domain.Entities;

namespace Application.Interfaces;

public interface IStudentRepository
{
    IReadOnlyCollection<Student> GetAllByGroupId(int groupId);
    Student? GetById(int id);
    void Add(Student student);
    void Remove(int id);    
    void SaveChanges();
}
