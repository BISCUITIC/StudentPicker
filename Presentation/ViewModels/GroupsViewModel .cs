using Application.Services;
using Domain.Entities;
using Presentation.Models;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels;

public class GroupsViewModel
{
    private readonly GroupService _groupProvider;
    private readonly ObservableCollection<GroupModel> _groups;    

    public ObservableCollection<GroupModel> Groups { get => _groups; }

    public GroupsViewModel(GroupService groupProvider)
    {
        _groupProvider = groupProvider;
        _groups = new ObservableCollection<GroupModel>();

        LoadGroups();
    }

    private void LoadGroups()
    {
        IReadOnlyCollection<Group> groups = _groupProvider.GetAllGroups();
        foreach (var group in groups)
        {
            _groups.Add(new GroupModel(group));
        }
    }
}
