namespace Application.UseCases.DTO;

public class UpdateStudentRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string SecondName { get; init; } = null!;
    public int GroupId { get; init; }
}
