namespace Application.UseCases.DTO;

public class AddStudentRequest
{
    public string Name { get; init; } = string.Empty;
    public string SecondName { get; init; } = string.Empty;
    public int GroupId { get; init; }
}
