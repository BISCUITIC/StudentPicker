namespace Application.UseCases.Students.DTO;

public sealed record class StudentPickInfo(
    int Id,
    bool IsExcluded
);

public sealed record class PickStudentRequest(
    IReadOnlyCollection<StudentPickInfo> Items
);

