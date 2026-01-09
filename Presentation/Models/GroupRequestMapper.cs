using Application.UseCases.Groups.DTO;
using Presentation.Services.Dialogs.DTO;

namespace Presentation.Models;

internal static class GroupRequestMapper
{
    public static UpdateGroupRequest ToUpdateGroupRequest(GroupDialogResult dialogResult, int groupId)
    {
        return new UpdateGroupRequest(Id: groupId,
                                      Number: dialogResult.Number,
                                      Letter: dialogResult.Letter);
    }

    public static DeleteGroupRequest ToDeleteGroupRequest(int groupId)
    {
        return new DeleteGroupRequest(Id: groupId);
    }

    public static AddGroupRequest ToAddGroupRequest(GroupDialogResult dialogResult)
    {
        return new AddGroupRequest(Number: dialogResult.Number,
                                   Letter: dialogResult.Letter);
    }
}
