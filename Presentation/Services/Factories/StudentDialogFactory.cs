using Microsoft.Extensions.DependencyInjection;
using Presentation.Models;
using Presentation.Views;
using System.Windows;

namespace Presentation.Services.Factories;

public abstract class StudentDialogFactory
{
    private readonly IServiceProvider _serviceProvider;

    protected StudentDialogFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public StudentDialog CreateDialog(StudentModel? model = null)
    {
        StudentDialog dialog = _serviceProvider.GetRequiredService<StudentDialog>();

        CentrolizedDialog(dialog);
        ConfigureDialog(dialog, model);
        return dialog;
    }

    private void CentrolizedDialog(StudentDialog dialog)
    {
        dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        dialog.Owner = System.Windows.Application.Current.MainWindow;
    }
    protected abstract void ConfigureDialog(StudentDialog dialog, StudentModel? model);
}
