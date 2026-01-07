using CommunityToolkit.Mvvm.Input;
using Presentation.Models;
using Presentation.ViewModels.Students;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace Presentation.ViewModels.Groups;

public class GroupItemViewModel : INotifyPropertyChanged
{
    private readonly GroupModel _group;
    public GroupModel Group { get => _group; }

    public ICommand DeleteGroupCommand { get; }
    public ICommand UpdateGroupCommand { get; }

    public event Action<GroupItemViewModel>? RequestDelete;
    public event Action<GroupItemViewModel>? RequestUpdate;

    public GroupItemViewModel(GroupModel group)
    {
        _group = group;

        DeleteGroupCommand = new RelayCommand(DeleteGroup);
        UpdateGroupCommand = new RelayCommand(UpdateGroup);
    }

    private void DeleteGroup()
    {
        RequestDelete?.Invoke(this);
    }

    private void UpdateGroup()
    {
        RequestUpdate?.Invoke(this);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
