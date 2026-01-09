namespace Application.UseCases.Student.DTO;

public sealed record class StudentDTO(
    int Id, 
    string Name, 
    string SecondName
);

