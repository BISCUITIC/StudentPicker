using Application.UseCases.Groups.DTO;
using Presentation.Services.Dialogs.DTO;

namespace Presentation.Models;

internal static class GroupModelMapper
{
    public static void UpdateModelFromDialogResult(GroupDialogResult result, GroupModel model)
    {
        model.Number = result.Number;
        model.Letter = result.Letter;
    }

    public static GroupModel ToModel(GroupDTO groupDTO)
    {
        return new GroupModel(groupDTO);
    }
}
