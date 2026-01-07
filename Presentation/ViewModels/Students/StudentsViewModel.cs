using Application.Services.Interfaces;
using Application.UseCases.DTO;
using CommunityToolkit.Mvvm.Input;
using Presentation.Models;
using Presentation.Services;
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
        if (groupModel == null)
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

    private void DeleteStudent(StudentItemViewModel studentModel)
    {
        _applicationService.Delete(Mapper.ToDeleteStudentRequest(studentModel.Student.Id));
        _students.Remove(studentModel);
    }

    private void UpdateStudent(StudentItemViewModel studentViewModel)
    {
        StudentDialogResult? result = _updateDialogService.ShowUpdateStudentDialog(studentViewModel.Student);

        if (result is not null)
        {
            _applicationService.Update(Mapper.ToUpdateStudentRequest(result, studentViewModel.Student.Id));

            StudentModelMapper.UpdateModelFromDialogResult(result, studentViewModel.Student);
        }
    }

    private void AddStudent()
    {
        if (CurrentGroup is null)
            return;

        StudentDialogResult? result = _addDialogService.ShowAddStudentDialog();

        if (result is null)
            return;

        AddStudentRequest request = Mapper.ToAddStudentRequest(result, CurrentGroup.Id);

        StudentDTO studentDto = _applicationService.Add(request);

        StudentModel studentModel = StudentModelMapper.ToModel(studentDto);

        AddNewStudentViewModel(studentModel);
    }

    private void PickRandomStudent()
    {
        int? pickedId = _applicationService.Pick(Mapper.ToPickStudentRequest(_students));

        if (pickedId is not null)
        {
            StudentItemViewModel? pickedStudent = _students.FirstOrDefault(studentModel => studentModel.Student.Id == pickedId);

            if (pickedStudent is not null)
                pickedStudent.Exclude();
        }
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
