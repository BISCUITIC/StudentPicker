using Application.UseCases.Groups.DTO;
using Application.UseCases.Groups.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.Models;
using Presentation.Services.Dialogs.DTO;
using Presentation.Services.Dialogs.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModels.Groups;

public class GroupsViewModel
{
    private readonly ILoadGroupsUseCase _loadGroupsUseCase;
    private readonly IAddGroupUseCase _addGroupUseCase;
    private readonly IDeleteGroupUseCase _deleteGroupUseCase;
    private readonly IUpdateGroupUseCase _updateGroupUseCase;

    private readonly IAddGroupDialogService _addDialogService;
    private readonly IUpdateGroupDialogService _updateDialogService;

    private readonly ObservableCollection<GroupItemViewModel> _groups;

    public ObservableCollection<GroupItemViewModel> Groups { get => _groups; }

    public ICommand LoadGroupCommand { get; }
    public ICommand AddGroupCommand { get; }

    public GroupsViewModel(ILoadGroupsUseCase loadGroupsUseCase,
                           IAddGroupUseCase addGroupUseCase,
                           IDeleteGroupUseCase deleteGroupUseCase,
                           IUpdateGroupUseCase updateGroupUseCase,
                           IAddGroupDialogService addGroupDialogService,
                           IUpdateGroupDialogService updateGroupDialogService)
    {
        _loadGroupsUseCase = loadGroupsUseCase;
        _addGroupUseCase = addGroupUseCase;
        _deleteGroupUseCase = deleteGroupUseCase;
        _updateGroupUseCase = updateGroupUseCase;

        _addDialogService = addGroupDialogService;
        _updateDialogService = updateGroupDialogService;

        _groups = new ObservableCollection<GroupItemViewModel>();

        LoadGroupCommand = new RelayCommand(LoadGroups);
        AddGroupCommand = new RelayCommand(AddGroup);
    }

    private void LoadGroups()
    {
        IReadOnlyCollection<GroupDTO> groupsDTO = _loadGroupsUseCase.Execute();

        foreach (GroupDTO grouptDTO in groupsDTO)
        {
            GroupModel groupModel = GroupModelMapper.ToModel(grouptDTO);
            AddNewGroupViewModel(groupModel);
        }
    }

    private void DeleteGroup(GroupItemViewModel groupModel)
    {
        _deleteGroupUseCase.Execute(GroupRequestMapper.ToDeleteGroupRequest(groupModel.Group.Id));
        _groups.Remove(groupModel);
    }

    private void UpdateGroup(GroupItemViewModel groupModel)
    {
        GroupDialogResult? result = _updateDialogService.ShowUpdateGroupDialog(groupModel.Group);

        if (result is not null)
        {
            _updateGroupUseCase.Execute(GroupRequestMapper.ToUpdateGroupRequest(result, groupModel.Group.Id));
            StudentModelMapper.UpdateModelFromDialogResult(result, groupModel.Group);
        }
    }
    private void AddGroup()
    {
        GroupDialogResult? result = _addDialogService.ShowAddGroupDialog();

        if (result is not null)
        {
            Group group = StudentModelMapper.ToDomain(result);

            AddGroupRequest groupRequest = GroupRequestMapper.ToAddGroupRequest(result);
            GroupDTO groupDTO = _addGroupUseCase.Execute(groupRequest);
            GroupModel groupModel = GroupModelMapper.ToModel(groupDTO);

            AddNewGroupViewModel(groupModel);
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
