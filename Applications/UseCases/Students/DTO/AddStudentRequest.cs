namespace Application.UseCases.Students.DTO;

public sealed record class AddStudentRequest(
    string Name,
    string SecondName,
    int GroupId
);