using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Presentation.Models;
using System.Windows;

namespace Presentation.Services.Factories;

public abstract class StudentDialogFactory
{
    private readonly IServiceProvider _serviceProvider;

    protected StudentDialogFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IStudentDialog CreateDialog(StudentModel? model = null)
    {
        IStudentDialog dialog = _serviceProvider.GetRequiredService<IStudentDialog>();

        CentrolizedDialog(dialog);
        ConfigureDialog(dialog, model);
        return dialog;
    }

    private void CentrolizedDialog(IStudentDialog dialog)
    {
        dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        dialog.Owner = System.Windows.Application.Current.MainWindow;
    }
    protected abstract void ConfigureDialog(IStudentDialog dialog, StudentModel? model);
}
