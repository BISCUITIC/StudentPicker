namespace Application.UseCases.DTO;

public class AddStudentRequest
{
    public string Name { get; init; } = null!;
    public string SecondName { get; init; } = null!;
    public int GroupId { get; init; }
}
