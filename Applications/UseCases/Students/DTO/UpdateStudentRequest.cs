namespace Application.UseCases.Students.DTO;

public sealed record class UpdateStudentRequest(
    int Id,
    string Name,
    string SecondName    
);
