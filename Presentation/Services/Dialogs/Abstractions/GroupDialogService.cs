using Presentation.Interfaces;
using Presentation.Services.Dialogs.DTO;
using Presentation.ViewModels.Dialogs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation.Services.Dialogs.Abstractions;

public abstract class GroupDialogService : DialogService<GroupDialogResult, 
                                                         GroupDialogViewModel, 
                                                         IGroupDialog>
{
    protected override GroupDialogResult GetResult(GroupDialogViewModel context)
    {
        return new GroupDialogResult(Number: context.Number, Letter: context.Letter[0]);
    }
}
