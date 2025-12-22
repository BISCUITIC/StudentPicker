using Presentation.ViewModels.Dialogs;

namespace Presentation.Interfaces;

public interface IGroupDialog : IDialog
{
    GroupDialogViewModel Context { get; }
}
