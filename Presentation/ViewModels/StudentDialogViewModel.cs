using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Presentation.ViewModels;

public class StudentDialogViewModel
{
    public string? Name { get; set; }
    public string? SecondName { get; set; }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public event Action<bool>? ResultRequest;

    public StudentDialogViewModel()
    {
        SaveCommand = new RelayCommand(Save);
        CancelCommand = new RelayCommand(Cancel);
    }

    public void Save()
    {
        ResultRequest?.Invoke(true);
    }

    public void Cancel()
    {
        ResultRequest?.Invoke(false);
    }
}
