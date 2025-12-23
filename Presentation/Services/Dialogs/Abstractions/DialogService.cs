using Presentation.Interfaces;
using Presentation.ViewModels.Dialogs;

namespace Presentation.Services.Dialogs.Abstractions;

public abstract class DialogService<Result, Context, Dialog>
       where Result : class
       where Context : DialogViewModel
       where Dialog : IDialog
{
    protected Result? ShowInternal(Dialog dialog, Context context)
    {
        if (IsDialogConfirmed(dialog))
        {
            return GetResult(context);
        }
        else
        {
            return null;
        }
    }

    protected bool IsDialogConfirmed(Dialog dialog)
    {
        return dialog.ShowDialog() == true;
    }

    protected abstract Result GetResult(Context context);
}
