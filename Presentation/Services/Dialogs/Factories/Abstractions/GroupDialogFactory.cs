using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services.Dialogs.Factories.Abstractions;

public abstract class GroupDialogFactory : DialogFactory<IGroupDialog, GroupModel>
{
    protected GroupDialogFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }
}
