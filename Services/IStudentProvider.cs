using Data.Model;

namespace Services;

internal interface IStudentProvider
{
    List<Student> GetStudents(int groupNumber, char groupLetter);
}
