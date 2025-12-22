using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services.Dialogs.Factories.Abstractions;

namespace Presentation.Services.Dialogs.Factories;

public class UpdateGroupDialogFactory : GroupDialogFactory
{
    public UpdateGroupDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override void ConfigureDialog(IGroupDialog dialog, GroupModel? model)
    {
        dialog.Title = "Update student";
        if (model is not null)
        {
            dialog.Context.Number = model.Number;
            dialog.Context.Letter = model.Letter.ToString();
        }
    }    
}
