namespace Application.UseCases.Groups.DTO;

public sealed record class AddGroupRequest(
    int Number,
    char Letter
);
