namespace Domain.Entities;

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
        Name= name;
        SecondName= secondName;
        FullName= Name + " " + SecondName;

        StudyGroup = studyGroup;
        GroupId = studyGroup.Id;
    }

    public Student(string name, string secondName, int studyGroupId)
    {
        Name = name;
        SecondName = secondName;
        FullName = Name + " " + SecondName;
        
        GroupId = studyGroupId;
    }

    public void UpdateSecondName(string secondName)
    {        
        SecondName = secondName;
        FullName = Name + " " + SecondName;
    }

    public void UpdateName(string name)
    {
        Name = name;
        FullName = Name + " " + SecondName;
    }
}
