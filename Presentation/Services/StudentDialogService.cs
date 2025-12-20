using Microsoft.Extensions.DependencyInjection;
using Presentation.Services.DTO;
using Presentation.ViewModels;
using Presentation.Views;

namespace Presentation.Services;

public abstract class StudentDialogService
{
    private readonly IServiceProvider _serviceProvider;
    
    public StudentDialogService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;        
    }

    protected StudentDialog CreateDialog()
    {
        return _serviceProvider.GetRequiredService<StudentDialog>();        
    }

    protected bool IsDialogConfirmedAndValid(StudentDialog dialog, StudentDialogViewModel context)
    {
        return dialog.ShowDialog() == true && DialogNotEmpty(context);
    }

    protected StudentDialogResult GetResult(StudentDialogViewModel context)
    {
        return new StudentDialogResult() { Name = context.Name, SecondName = context.SecondName };
    }

    private bool DialogNotEmpty(StudentDialogViewModel context)
    {
        return !string.IsNullOrWhiteSpace(context.Name) &&
               !string.IsNullOrWhiteSpace(context.SecondName);
    }
}
