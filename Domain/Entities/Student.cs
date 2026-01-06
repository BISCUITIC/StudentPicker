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

    public Student(string name, string secondName, int groupId)
    {
        Name= name;
        SecondName= secondName;
        FullName= Name + " " + SecondName;

        GroupId = groupId;        
    }

    public Student(int id, string name, string secondName, int groupId)
    {
        Id = id;
        Name = name;
        SecondName = secondName;
        FullName = Name + " " + SecondName;

        GroupId = groupId;
    }

    public void UpdateName(string name)
    {
        Name = name;    
    }

    public void UpdateSecondName(string secondName)
    {
        SecondName = secondName;
    }
}
