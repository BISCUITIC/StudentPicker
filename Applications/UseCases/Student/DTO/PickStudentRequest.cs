namespace Application.UseCases.Student.DTO;

public sealed record class StudentPickInfo(
    int Id,
    bool IsExcluded
);

public sealed record class PickStudentRequest(
    IReadOnlyCollection<StudentPickInfo> Items
);

