using Presentation.ViewModels;
using System.Windows;

namespace Presentation.Views;

/// <summary>
/// Логика взаимодействия для AddStudentDialog.xaml
/// </summary>
public partial class AddStudentDialog : Window
{
    public AddStudentDialogViewModel Context { get; private set; }

    public AddStudentDialog(AddStudentDialogViewModel dialogContext)
    {
        InitializeComponent();

        Context = dialogContext;
        Context.ResultRequest += (result) => { DialogResult = result; };
        DataContext = Context;
    }
}
