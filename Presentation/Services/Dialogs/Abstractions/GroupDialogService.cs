using Presentation.Interfaces;
using Presentation.Services.DTO;
using Presentation.ViewModels.Dialogs;

namespace Presentation.Services.Dialogs.Abstractions;

public abstract class GroupDialogService : DialogService<GroupDialogResult, 
                                                         GroupDialogViewModel, 
                                                         IGroupDialog>
{
    protected override GroupDialogResult GetResult(GroupDialogViewModel context)
    {
        return new GroupDialogResult() { Number = context.Number, Letter = context.Letter[0] };
    }
}
