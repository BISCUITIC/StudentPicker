using Presentation.Models;
using Presentation.Services.Dialogs.DTO;

namespace Presentation.Services.Dialogs.Interfaces;

public interface IUpdateGroupDialogService
{
    GroupDialogResult? ShowUpdateGroupDialog(GroupModel groupModel);
}
