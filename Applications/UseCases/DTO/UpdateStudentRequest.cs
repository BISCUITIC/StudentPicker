namespace Application.UseCases.DTO;

public sealed record class UpdateStudentRequest(
    int Id,
    string Name,
    string SecondName    
);
