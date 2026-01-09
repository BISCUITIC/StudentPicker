using Application.UseCases.Groups.DTO;

namespace Presentation.Models;

internal static class GroupModelMapper
{
    public static GroupModel ToModel(GroupDTO groupDTO)
    {
        return new GroupModel(groupDTO);
    }
}
