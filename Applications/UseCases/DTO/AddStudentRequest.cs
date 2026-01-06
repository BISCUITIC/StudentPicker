namespace Application.UseCases.DTO;

public sealed record class AddStudentRequest(
    string Name,
    string SecondName,
    int GroupId
);