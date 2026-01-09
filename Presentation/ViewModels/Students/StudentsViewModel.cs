using Application.Services.Interfaces.Facades;
using Application.UseCases.Students.DTO;
using CommunityToolkit.Mvvm.Input;
using Presentation.Models;
using Presentation.Services.Dialogs.DTO;
using Presentation.Services.Dialogs.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModels.Students;

public class StudentsViewModel
{
    private readonly IStudentApplicationService _applicationService;

    private readonly IAddStudentDialogService _addDialogService;
    private readonly IUpdateStudentDialogService _updateDialogService;


    private GroupModel? _currentGroup;
    public GroupModel? CurrentGroup
    {
        get => _currentGroup;
        set { _currentGroup = value; OnCurrentGroupChanged(); }
    }

    private readonly ObservableCollection<StudentItemViewModel> _students;

    public ObservableCollection<StudentItemViewModel> Students { get => _students; }

    public ICommand LoadStudentsCommand { get; }
    public IRelayCommand AddStudentCommand { get; }
    public IRelayCommand PickRandomStudentCommand { get; }

    public StudentsViewModel(IAddStudentDialogService addDialogService,
                             IUpdateStudentDialogService studentDialogService,
                             IStudentApplicationService studentApplicationService)
    {
        _addDialogService = addDialogService;
        _updateDialogService = studentDialogService;

        _applicationService = studentApplicationService;

        _students = new ObservableCollection<StudentItemViewModel>();

        LoadStudentsCommand = new RelayCommand<GroupModel>(LoadStudents);
        AddStudentCommand = new RelayCommand(AddStudent, CanInteract);
        PickRandomStudentCommand = new RelayCommand(PickRandomStudent, CanInteract);
    }

    private void LoadStudents(GroupModel? groupModel)
    {
        if (groupModel is null)
            return;

        CurrentGroup = groupModel;
        _students.Clear();

        IReadOnlyCollection<StudentDTO> studentsDTO = _applicationService.Load(groupModel.Id);

        foreach (StudentDTO studentDTO in studentsDTO)
        {
            StudentModel studentModel = StudentModelMapper.ToModel(studentDTO);
            AddNewStudentViewModel(studentModel);
        }
    }

    private void DeleteStudent(StudentItemViewModel studentViewModel)
    {
        DeleteStudentRequest request = StudentRequestMapper.ToDeleteStudentRequest(studentViewModel.Student.Id);
        _applicationService.Delete(request);
        _students.Remove(studentViewModel);
    }

    private void UpdateStudent(StudentItemViewModel studentViewModel)
    {
        StudentDialogResult? result = _updateDialogService.ShowUpdateStudentDialog(studentViewModel.Student);

        if (result is null)
            return;

        UpdateStudentRequest request = StudentRequestMapper.ToUpdateStudentRequest(result, studentViewModel.Student.Id);
        _applicationService.Update(request);
        StudentModelMapper.UpdateModelFromDialogResult(result, studentViewModel.Student);        
    }

    private void AddStudent()
    {
        if (CurrentGroup is null)
            return;

        StudentDialogResult? result = _addDialogService.ShowAddStudentDialog();

        if (result is null)
            return;

        AddStudentRequest request = StudentRequestMapper.ToAddStudentRequest(result, CurrentGroup.Id);
        StudentDTO studentDTO = _applicationService.Add(request);
        StudentModel studentModel = StudentModelMapper.ToModel(studentDTO);

        AddNewStudentViewModel(studentModel);
    }

    private void PickRandomStudent()
    {
        PickStudentRequest request = StudentRequestMapper.ToPickStudentRequest(_students);
        int? pickedId = _applicationService.Pick(request);

        if (pickedId is null)
            return;

        StudentItemViewModel? pickedStudent = _students.FirstOrDefault(studentModel => studentModel.Student.Id == pickedId);

        if (pickedStudent is not null)
            pickedStudent.Exclude();        
    }

    private void AddNewStudentViewModel(StudentModel student)
    {
        StudentItemViewModel newItem = new StudentItemViewModel(student);

        newItem.RequestDelete += DeleteStudent;
        newItem.RequestUpdate += UpdateStudent;

        _students.Add(newItem);
    }

    private bool CanInteract() => CurrentGroup is not null;
    private void OnCurrentGroupChanged()
    {
        AddStudentCommand.NotifyCanExecuteChanged();
        PickRandomStudentCommand.NotifyCanExecuteChanged();
    }
}
