namespace Data.Model;

public class Student
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string SecondName { get; private set; } = null!;
    public string FullName { get; private set; } = null!;

    public int GroupId { get; private set; }
    public Group StudyGroup { get; private set; }

    private Student() { } // Конструктор без параметров для EF core чтобы он мог сопоставить сущности

    public Student(string name, string secondName, Group studyGroup)
    {
        Name = name;
        SecondName = secondName;
        FullName = name + " " + secondName;

        StudyGroup = studyGroup;
        GroupId = studyGroup.Id;
    }
}
