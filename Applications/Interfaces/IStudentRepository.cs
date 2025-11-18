using Domain.Entities;

namespace Application.Interfaces;

public interface IStudentRepository
{
    List<Student> GetByGroup(Group group);
}
