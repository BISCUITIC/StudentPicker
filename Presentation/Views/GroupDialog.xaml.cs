using Presentation.Interfaces;
using Presentation.ViewModels.Dialogs;
using System.Windows;

namespace Presentation.Views;

/// <summary>
/// Логика взаимодействия для GroupDialog.xaml
/// </summary>
public partial class GroupDialog : Window, IGroupDialog
{
    public GroupDialogViewModel Context { get; private set; }

    public GroupDialog(GroupDialogViewModel dialogContext)
    {
        InitializeComponent();

        Context = dialogContext;
        Context.ResultRequest += (result) => { DialogResult = result; };
        DataContext = Context;
    }

}
