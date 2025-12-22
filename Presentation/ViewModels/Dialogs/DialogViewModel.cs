using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Presentation.ViewModels.Dialogs;

public abstract class DialogViewModel
{
    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public event Action<bool>? ResultRequest;

    public DialogViewModel()
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
