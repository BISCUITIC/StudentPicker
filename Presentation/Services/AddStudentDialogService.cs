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
        AddStudentDialogViewModel? context = dialog.DataContext as AddStudentDialogViewModel;

        if (dialog.ShowDialog() == true && context is not null)
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
}
