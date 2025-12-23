using Presentation.Interfaces;
using Presentation.Services.Dialogs.Abstractions;
using Presentation.Services.Dialogs.Factories;
using Presentation.Services.DTO;
using Presentation.Services.Interfaces;
using System.Windows;

namespace Presentation.Services.Dialogs;

public class AddGroupDialogService : GroupDialogService, IAddGroupDialogService
{
    private readonly AddGroupDialogFactory _dialogFactory;

    public AddGroupDialogService(AddGroupDialogFactory dialogFactory)
    {
        _dialogFactory = dialogFactory;
    }

    public GroupDialogResult? ShowAddGroupDialog()
    {       
        IGroupDialog dialog = _dialogFactory.CreateDialog();        
        return ShowInternal(dialog, dialog.Context);
    }
}
