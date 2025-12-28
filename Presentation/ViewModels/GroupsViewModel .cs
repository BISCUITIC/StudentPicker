using Application.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.Models;
using Presentation.Services.DTO;
using Presentation.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModels;

public class GroupsViewModel
{
    private readonly IGroupService _groupService;
    private readonly IAddGroupDialogService _addDialogService;
    private readonly IUpdateGroupDialogService _updateDialogService;

    private readonly ObservableCollection<GroupModel> _groups;

    public ObservableCollection<GroupModel> Groups { get => _groups; }

    public ICommand LoadGroupCommand { get; }
    public ICommand DeleteGroupCommand { get; }
    public ICommand UpdateGroupCommand { get; }
    public ICommand AddGroupCommand { get; }

    public GroupsViewModel(IGroupService groupProvider,
                           IAddGroupDialogService addGroupDialogService,
                           IUpdateGroupDialogService updateGroupDialogService)
    {
        _groupService = groupProvider;
        _addDialogService = addGroupDialogService;
        _updateDialogService = updateGroupDialogService;

        _groups = new ObservableCollection<GroupModel>();

        LoadGroupCommand = new RelayCommand(LoadGroups);
        DeleteGroupCommand = new RelayCommand<GroupModel>(DeleteGroup);
        UpdateGroupCommand = new RelayCommand<GroupModel>(UpdateGroup);
        AddGroupCommand = new RelayCommand(AddGroup);
    }

    private void LoadGroups()
    {
        IReadOnlyCollection<Group> groups = _groupService.GetAllGroups();
        foreach (var group in groups)
        {
            _groups.Add(new GroupModel(group));
        }
    }

    private void DeleteGroup(GroupModel? groupModel)
    {
        if (groupModel == null)
            return;

        _groupService.DeleteGroup(groupModel.Id);
        _groups.Remove(groupModel);
    }
    private void UpdateGroup(GroupModel? groupModel)
    {
        if (groupModel == null)
            return;

        GroupDialogResult? result = _updateDialogService.ShowUpdateGroupDialog(groupModel);

        if (result is not null)
        {
            StudentMapper.UpdateModelFromDialogResult(result, groupModel);
            Group group = StudentMapper.ToDomain(groupModel);

            _groupService.UpdateGroup(group);
        }
    }
    private void AddGroup()
    {
        GroupDialogResult? result = _addDialogService.ShowAddGroupDialog();

        if (result is not null)
        {
            Group group = StudentMapper.ToDomain(result);

            _groupService.AddGroup(group);
            _groups.Add(new GroupModel(group));
        }
    }

}
