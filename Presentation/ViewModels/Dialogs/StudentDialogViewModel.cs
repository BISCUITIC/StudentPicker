using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.ViewModels.Dialogs;

public class StudentDialogViewModel : DialogViewModel, INotifyPropertyChanged
{
    public string? Name { get; set; }
    public string? SecondName { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
