using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.ViewModels.Dialogs;

public class GroupDialogViewModel : DialogViewModel, INotifyPropertyChanged
{
    public int Number { get; set; }
    public string? Letter { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
