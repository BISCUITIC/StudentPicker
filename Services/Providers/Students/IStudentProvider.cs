using Data.Model;

namespace Services.Providers.Students;

public interface IStudentProvider
{
    List<Student> GetStudents(int groupNumber, char groupLetter);
}
