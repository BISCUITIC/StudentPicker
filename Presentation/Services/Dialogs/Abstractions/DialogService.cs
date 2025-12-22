using Presentation.Interfaces;

namespace Presentation.Services.Dialogs.Abstractions;

public abstract class DialogService<Result, Context, Dialog>
       where Result : class
       where Context : class
       where Dialog : IDialog
{
    protected Result? ShowInternal(Dialog dialog, Context context)
    {
        if (IsDialogConfirmedAndValid(dialog, context))
        {
            return GetResult(context);
        }
        else
        {
            return null;
        }
    }

    protected abstract Result GetResult(Context context);

    protected abstract bool IsDialogConfirmedAndValid(Dialog dialog, Context context);
}
