using Data.Model;

namespace Services;

public interface IStudentProvider
{
    List<Student> GetStudents(int groupNumber, char groupLetter);
}
