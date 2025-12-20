using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Presentation.ViewModels;

public class AddStudentDialogViewModel
{
    public string? Name { get; set; }
    public string? SecondName { get; set; }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public event Action<bool>? ResultRequest;

    public AddStudentDialogViewModel()
    {
        SaveCommand = new RelayCommand(Add);
        CancelCommand = new RelayCommand(Cancel);
    }

    public void Add()
    {
        ResultRequest?.Invoke(true);
    }

    public void Cancel()
    {
        ResultRequest?.Invoke(false);
    }
}
