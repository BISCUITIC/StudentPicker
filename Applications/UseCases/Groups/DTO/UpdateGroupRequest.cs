namespace Application.UseCases.Groups.DTO;

public sealed record class UpdateGroupRequest(
    int Id,
    int Number,
    char Letter
);
