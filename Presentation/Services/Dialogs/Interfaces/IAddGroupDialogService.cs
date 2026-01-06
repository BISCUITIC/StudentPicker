using Presentation.Services.Dialogs.DTO;

namespace Presentation.Services.Dialogs.Interfaces;

public interface IAddGroupDialogService
{
    GroupDialogResult? ShowAddGroupDialog();
}
