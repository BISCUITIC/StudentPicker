using Domain.Entities;

namespace Application.Interfaces;

public interface IStudentRepository
{
    List<Student> GetAllByGroup(Group group);
}
