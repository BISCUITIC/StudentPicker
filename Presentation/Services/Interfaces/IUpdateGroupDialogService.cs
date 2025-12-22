using Presentation.Models;
using Presentation.Services.DTO;

namespace Presentation.Services.Interfaces;

public interface IUpdateGroupDialogService
{
    GroupDialogResult? ShowUpdateGroupDialog(GroupModel groupModel);
}
