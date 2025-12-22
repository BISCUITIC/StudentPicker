using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using System.Windows;

namespace Presentation.Services.Dialogs.Factories.Abstractions;

public abstract class DialogFactory<Dialog, Model>
       where Dialog : IDialog
       where Model : class
{
    private readonly IServiceProvider _serviceProvider;

    protected DialogFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Dialog CreateDialog(Model? model = null)
    {        
        Dialog dialog = _serviceProvider.GetRequiredService<Dialog>();        

        CentrolizedDialog(dialog);
        ConfigureDialog(dialog, model);
        return dialog;
    }

    private void CentrolizedDialog(Dialog dialog)
    {
        dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        dialog.Owner = System.Windows.Application.Current.MainWindow;
    }

    protected abstract void ConfigureDialog(Dialog dialog, Model? model);
}
