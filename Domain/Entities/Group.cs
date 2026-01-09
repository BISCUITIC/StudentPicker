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

    public Group(int id, int number, char letter)
    {
        Id = id;
        Number = number;
        Letter = letter;
    }
    public void UpdateNumber(int number)
    {
        Number = number;
    }

    public void UpdateLetter(char letter)
    {
        Letter = letter;
    }

}
