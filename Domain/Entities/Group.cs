namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public int Number { get; private set; }
    public char Letter { get; private set; }

    public List<Student> Students { get; private set; } = new List<Student>();

    public Group(int number, char letter)
    {
        Number = number;
        Letter = letter;
    }
}
