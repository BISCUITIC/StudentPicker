using CommunityToolkit.Mvvm.Input;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModels.Dialogs;

public abstract class DialogViewModel : INotifyPropertyChanged
{
    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public event Action<bool>? ResultRequest;

    public string? _errorMessage;
    public string? ErrorMessage
    {
        get => _errorMessage;
        protected set { _errorMessage = value; OnPropertyChanged(); }
    }

    public DialogViewModel()
    {
        _errorMessage = null;
        SaveCommand = new RelayCommand(Save);
        CancelCommand = new RelayCommand(Cancel);
    }

    protected abstract bool CanSave();

    public void Save()
    {
        if(CanSave())
            ResultRequest?.Invoke(true);
    }

    public void Cancel()
    {
        ResultRequest?.Invoke(false);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
