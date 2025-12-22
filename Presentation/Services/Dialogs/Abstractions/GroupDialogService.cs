using Presentation.Interfaces;
using Presentation.Services.DTO;
using Presentation.ViewModels.Dialogs;
using System.Windows;

namespace Presentation.Services.Dialogs.Abstractions;

public abstract class GroupDialogService : DialogService<GroupDialogResult, GroupDialogViewModel, IGroupDialog>
{
    protected override GroupDialogResult GetResult(GroupDialogViewModel context)
    {
        MessageBox.Show(context.Number.ToString());
        MessageBox.Show(context.Letter[0].ToString());
        return new GroupDialogResult() { Number = context.Number, Letter = context.Letter[0] };
    }

    protected override bool IsDialogConfirmedAndValid(IGroupDialog dialog, GroupDialogViewModel context)
    {
        return dialog.ShowDialog() == true && DialogValid(context);
    }

    private bool DialogValid(GroupDialogViewModel context)
    {
        return context.Number > 0 && context.Number < 11 &&
               !string.IsNullOrEmpty(context.Letter) &&
               char.IsLetter(context.Letter[0]);
    }
}
