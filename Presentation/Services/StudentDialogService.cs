using Microsoft.Extensions.DependencyInjection;
using Presentation.Services.DTO;
using Presentation.ViewModels;
using Presentation.Views;
using System;

namespace Presentation.Services;

public abstract class StudentDialogService
{
    private readonly IServiceProvider _serviceProvider;

    private StudentDialog _studentDialog = null!;
    private StudentDialogViewModel _studentDialogContext = null!;

    public StudentDialogService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CreateDialog();
    }

    protected void CreateDialog()
    {        
        _studentDialog = _serviceProvider.GetRequiredService<StudentDialog>();
        _studentDialogContext = _studentDialog.Context;
    }

    protected bool IsDialogConfirmedAndValid()
    {
        return _studentDialog.ShowDialog() == true && DialogNotEmpty();
    }

    protected StudentDialogResult GetResult()
    {
        return new StudentDialogResult() { Name = _studentDialogContext.Name, SecondName = _studentDialogContext.SecondName };
    }

    private bool DialogNotEmpty()
    {
        return !string.IsNullOrWhiteSpace(_studentDialogContext.Name) && 
               !string.IsNullOrWhiteSpace(_studentDialogContext.SecondName);
    }
}
