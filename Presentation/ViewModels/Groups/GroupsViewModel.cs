using Application.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.Models;
using Presentation.Services.Dialogs.DTO;
using Presentation.Services.Dialogs.Interfaces;
using Presentation.ViewModels.Students;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels.Groups;

public class GroupsViewModel
{
    private readonly IGroupService _groupService;
    private readonly IAddGroupDialogService _addDialogService;
    private readonly IUpdateGroupDialogService _updateDialogService;

    private readonly ObservableCollection<GroupItemViewModel> _groups;

    public ObservableCollection<GroupItemViewModel> Groups { get => _groups; }

    public ICommand LoadGroupCommand { get; }
    public ICommand AddGroupCommand { get; }

    public GroupsViewModel(IGroupService groupProvider,
                           IAddGroupDialogService addGroupDialogService,
                           IUpdateGroupDialogService updateGroupDialogService)
    {
        _groupService = groupProvider;
        _addDialogService = addGroupDialogService;
        _updateDialogService = updateGroupDialogService;

        _groups = new ObservableCollection<GroupItemViewModel>();

        LoadGroupCommand = new RelayCommand(LoadGroups);
        AddGroupCommand = new RelayCommand(AddGroup);
    }

    private void LoadGroups()
    {
        IReadOnlyCollection<Group> groups = _groupService.GetAllGroups();
        foreach (var group in groups)
        {            
            AddNewGroupViewModel(new GroupModel(group));
        }
    }

    private void DeleteGroup(GroupItemViewModel groupModel)
    {
        _groupService.DeleteGroup(groupModel.Group.Id);
        _groups.Remove(groupModel);
    }

    private void UpdateGroup(GroupItemViewModel groupModel)
    {
        GroupDialogResult? result = _updateDialogService.ShowUpdateGroupDialog(groupModel.Group);

        if (result is not null)
        {
            StudentModelMapper.UpdateModelFromDialogResult(result, groupModel.Group);
            Group group = StudentModelMapper.ToDomain(groupModel.Group);

            _groupService.UpdateGroup(group);
        }
    }
    private void AddGroup()
    {
        GroupDialogResult? result = _addDialogService.ShowAddGroupDialog();

        if (result is not null)
        {
            Group group = StudentModelMapper.ToDomain(result);

            _groupService.AddGroup(group);
            AddNewGroupViewModel(new GroupModel(group));
        }
    }
    
    private void AddNewGroupViewModel(GroupModel groupModel)
    {
        GroupItemViewModel newItem = new GroupItemViewModel(groupModel);

        newItem.RequestDelete += DeleteGroup;
        newItem.RequestUpdate += UpdateGroup;

        _groups.Add(newItem);
    }
}
