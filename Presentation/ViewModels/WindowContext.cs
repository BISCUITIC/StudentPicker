using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModels;

public class WindowContext
{
    private readonly GroupsViewModel _groupsViewModel;
    private readonly StudentsViewModel _studentsViewModel;

    public ObservableCollection<Group> Groups { get => _groupsViewModel.Groups; }
    public ObservableCollection<Student> Students { get => _studentsViewModel.Students; }

    public WindowContext(GroupsViewModel groupsViewModel, StudentsViewModel studentsViewModel)
    {
        _groupsViewModel = groupsViewModel;
        _studentsViewModel = studentsViewModel;
    }

    public void LoadGroup_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Group? group = (e.Parameter as Group);

        if (group is not null)
            _studentsViewModel.LoadStudents(group);
    }
}
