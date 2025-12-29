using Presentation.Models;
using Presentation.Services.DTO;

namespace Presentation.Services.Dialogs.Interfaces;

public interface IUpdateGroupDialogService
{
    GroupDialogResult? ShowUpdateGroupDialog(GroupModel groupModel);
}
