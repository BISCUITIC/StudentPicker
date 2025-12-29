namespace Application.UseCases.DTO;

public class PickData
{
    public int Id { get; init; }
    public bool IsExcluded { get; init; }
}

public class PickStudentRequest
{
    public IReadOnlyCollection<PickData> Data { get; init; }
}
