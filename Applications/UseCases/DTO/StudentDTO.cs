namespace Application.UseCases.DTO;

public sealed class StudentDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string SecondName { get; init; } = string.Empty;
}
