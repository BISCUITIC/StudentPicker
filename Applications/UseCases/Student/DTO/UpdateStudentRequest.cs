namespace Application.UseCases.Student.DTO;

public sealed record class UpdateStudentRequest(
    int Id,
    string Name,
    string SecondName    
);
