using System.Collections.ObjectModel;
using Application.Services;
using Domain.Entities;

namespace Presentation.ViewModels;

public class GroupsViewModel
{
    private readonly GroupProvider _groupProvider;
    private readonly ObservableCollection<Group> _groups;

    public ObservableCollection<Group> Groups { get => _groups; }

    public GroupsViewModel(GroupProvider groupProvider)
    {
        _groupProvider = groupProvider;
        _groups = new ObservableCollection<Group>();

        LoadGroups();
    }

    private void LoadGroups()
    {
        IReadOnlyCollection<Group> groups = _groupProvider.GetGroups();
        foreach (var group in groups)
        {
            _groups.Add(group);
        }
    }
}
