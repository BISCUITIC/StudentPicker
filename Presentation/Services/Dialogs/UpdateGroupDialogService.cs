using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services.Dialogs.Abstractions;
using Presentation.Services.Dialogs.DTO;
using Presentation.Services.Dialogs.Factories;
using Presentation.Services.Dialogs.Interfaces;

namespace Presentation.Services.Dialogs;

public class UpdateGroupDialogService : GroupDialogService, IUpdateGroupDialogService
{
    private readonly UpdateGroupDialogFactory _dialogFactory;

    public UpdateGroupDialogService(UpdateGroupDialogFactory dialogFactory)
    {
        _dialogFactory = dialogFactory;
    }

    public GroupDialogResult? ShowUpdateGroupDialog(GroupModel groupModel)
    {
        IGroupDialog dialog = _dialogFactory.CreateDialog(groupModel);
        return ShowInternal(dialog, dialog.Context);
    }
}
