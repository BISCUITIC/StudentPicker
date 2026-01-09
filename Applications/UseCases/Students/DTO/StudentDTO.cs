namespace Application.UseCases.Students.DTO;

public sealed record class StudentDTO(
    int Id, 
    string Name, 
    string SecondName
);

