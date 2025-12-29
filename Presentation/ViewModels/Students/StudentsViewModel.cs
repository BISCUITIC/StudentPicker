using Application.Services.Interfaces;
using Application.UseCases;
using Application.UseCases.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.Models;
using Presentation.Services;
using Presentation.Services.Dialogs.Interfaces;
using Presentation.Services.DTO;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModels.Students;

public class StudentsViewModel
{
    private readonly ILoadStudentsUseCase _loadStudentsUseCase;
    private readonly IUpdateStudentUseCase _updateStudentUseCase;
    private readonly IDeleteStudentUseCase _deleteStudentUseCase;
    private readonly IAddStudentUseCase _addStudentUseCase;
    private readonly IPickStudentUseCase _pickStudentUseCase;

    private readonly IAddStudentDialogService _addDialogService;
    private readonly IUpdateStudentDialogService _updateDialogService;

    private GroupModel? _currentGroup;

    private readonly ObservableCollection<StudentItemViewModel> _students;
    public ObservableCollection<StudentItemViewModel> Students { get => _students; }

    public ICommand LoadStudentsCommand { get; }
    public IRelayCommand AddStudentCommand { get; }
    public IRelayCommand PickRandomStudentCommand { get; }

    public StudentsViewModel(IAddStudentDialogService addDialogService,
                             IUpdateStudentDialogService studentDialogService,
                             ILoadStudentsUseCase loadStudentsUseCase,
                             IUpdateStudentUseCase updateStudentUseCase,
                             IDeleteStudentUseCase deleteStudentUseCase,
                             IAddStudentUseCase addStudentUseCase,
                             IPickStudentUseCase pickStudentUseCase,
                             IStudentPickerService studentPickerService)
    {
        _addDialogService = addDialogService;
        _updateDialogService = studentDialogService;

        _loadStudentsUseCase = loadStudentsUseCase;
        _updateStudentUseCase = updateStudentUseCase;
        _deleteStudentUseCase = deleteStudentUseCase;
        _addStudentUseCase = addStudentUseCase;
        _pickStudentUseCase = pickStudentUseCase;        

        _students = new ObservableCollection<StudentItemViewModel>();

        LoadStudentsCommand = new RelayCommand<GroupModel>(LoadStudents);
        AddStudentCommand = new RelayCommand(AddStudent, IsStateValid);
        PickRandomStudentCommand = new RelayCommand(PickRandomStudent, IsStateValid);
    }

    private void LoadStudents(GroupModel? groupModel)
    {
        if (groupModel == null)
            return;

        _currentGroup = groupModel;
        _students.Clear();

        IReadOnlyCollection<Student> students = _loadStudentsUseCase.Execute(groupModel.Id);

        foreach (var student in students)
        {
            var newItem = new StudentItemViewModel(student);
            newItem.RequestDelete += DeleteStudent;
            newItem.RequestUpdate += UpdateStudent;

            _students.Add(newItem);
        }

        AddStudentCommand.NotifyCanExecuteChanged();
        PickRandomStudentCommand.NotifyCanExecuteChanged();
    }

    private void DeleteStudent(StudentItemViewModel studentModel)
    {
        _deleteStudentUseCase.Execute(Mapper.ToDeleteStudentRequest(studentModel.Student.Id));
        _students.Remove(studentModel);
    }

    private void UpdateStudent(StudentItemViewModel studentViewModel)
    {
        StudentDialogResult? result = _updateDialogService.ShowUpdateStudentDialog(studentViewModel.Student);

        if (result is not null)
        {
            _updateStudentUseCase.Execute(Mapper.ToUpdateStudentRequest(result, studentViewModel.Student.Id, _currentGroup!.Id));

            StudentModelMapper.UpdateModelFromDialogResult(result, studentViewModel.Student);
        }
    }

    private void AddStudent()
    {
        StudentDialogResult? result = _addDialogService.ShowAddStudentDialog();

        if (result is not null)
        {
            Student student = _addStudentUseCase.Execute(Mapper.ToAddStudentRequest(result, _currentGroup!.Id));
            _students.Add(new StudentItemViewModel(student));
        }
    }

    private void PickRandomStudent()
    {
        int? pickedId = _pickStudentUseCase.Execute(Mapper.ToPickStudentRequest(_students));

        if (pickedId is not null)
        {
            StudentItemViewModel? pickedStudent = _students.FirstOrDefault(studentModel => studentModel.Student.Id == pickedId);

            if (pickedStudent is not null)
                pickedStudent.Exclude();
        }
    }

    private bool IsStateValid() => _currentGroup is not null;
}
