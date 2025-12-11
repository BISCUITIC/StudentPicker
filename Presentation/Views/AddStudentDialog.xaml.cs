using Presentation.ViewModels;
using System.Windows;

namespace Presentation.Views;

/// <summary>
/// Логика взаимодействия для AddStudentDialog.xaml
/// </summary>
public partial class AddStudentDialog : Window
{
    public AddStudentDialog(AddStudentDialogViewModel dialogContext)
    {
        InitializeComponent();

        DataContext = dialogContext;
        dialogContext.ResultRequest += (result) => { DialogResult = result; };
    }
}
