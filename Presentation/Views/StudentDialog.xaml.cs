using Presentation.ViewModels;
using System.Windows;

namespace Presentation.Views;

/// <summary>
/// Логика взаимодействия для AddStudentDialog.xaml
/// </summary>
public partial class StudentDialog : Window
{
    public StudentDialogViewModel Context { get; private set; }

    public StudentDialog(StudentDialogViewModel dialogContext)
    {
        InitializeComponent();

        Context = dialogContext;
        Context.ResultRequest += (result) => { DialogResult = result; };
        DataContext = Context;
    }
}
