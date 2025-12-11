using Microsoft.Extensions.DependencyInjection;
using Presentation.Services.DTO;
using Presentation.Services.Interfacesl;
using Presentation.ViewModels;
using Presentation.Views;

namespace Presentation.Services;

public class AddStudentDialogService : IAddStudentDialogService
{
    private readonly IServiceProvider _serviceProvider;

    public AddStudentDialogService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public AddStudentResult? ShowAddStudentDialog()
    {
        AddStudentDialog dialog = _serviceProvider.GetRequiredService<AddStudentDialog>();
        AddStudentDialogViewModel context = dialog.Context;

        if (IsDialogConfirmedAndValid(dialog, context))
        {
            return new AddStudentResult()
            {
                Name = context.Name,
                SecondName = context.SecondName
            };
        }
        else
        {
            return null;
        }
    }

    private bool IsDialogConfirmedAndValid(AddStudentDialog dialog, AddStudentDialogViewModel context)
    {
        return dialog.ShowDialog() == true && DialogNotEmpty(context);
    }

    private bool DialogNotEmpty(AddStudentDialogViewModel context)
    {
        return !string.IsNullOrWhiteSpace(context.Name) && !string.IsNullOrWhiteSpace(context.SecondName);
    }
}
