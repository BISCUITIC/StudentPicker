using System.Windows;

namespace Presentation.ViewModels;

public class MainViewModel
{
    public GroupsViewModel GroupsViewModel { get; }
    public StudentsViewModel StudentsViewModel { get; }    

    public MainViewModel(GroupsViewModel groupsViewModel, StudentsViewModel studentsViewModel)
    {        
        GroupsViewModel = groupsViewModel;
        StudentsViewModel = studentsViewModel;
    }
}
