using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services.Dialogs.Factories.Abstractions;

namespace Presentation.Services.Dialogs.Factories;

public class AddGroupDialogFactory : GroupDialogFactory
{
    public AddGroupDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override void ConfigureDialog(IGroupDialog dialog, GroupModel? model)
    {
        dialog.Title = "Add group";
    }
}
