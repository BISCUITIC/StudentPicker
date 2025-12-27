using Application.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.Models;
using Presentation.Services.DTO;
using Presentation.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels;

public class StudentsViewModel : INotifyPropertyChanged
{
    private readonly IStudentService _studentService;
    private readonly IAddStudentDialogService _addDialogService;
    private readonly IUpdateStudentDialogService _updateDialogService;
    private readonly IStudentPickerService _studentPickerService;

    private readonly ObservableCollection<StudentModel> _students;

    private GroupModel? _currentGroup;

    public ObservableCollection<StudentModel> Students { get => _students; }

    public ICommand LoadStudentsCommand { get; }
    public ICommand DeleteStudentCommand { get; }
    public ICommand UpdateStudentCommand { get; }
    public ICommand AddStudentCommand { get; }

    public ICommand PickRandomStudentCommand { get; }

    public StudentsViewModel(IStudentService studentProvider,
                             IAddStudentDialogService addDialogService,
                             IUpdateStudentDialogService studentDialogService,
                             IStudentPickerService studentPickerService)
    {
        _studentService = studentProvider;
        _addDialogService = addDialogService;
        _updateDialogService = studentDialogService;
        _studentPickerService = studentPickerService;

        _students = new ObservableCollection<StudentModel>();

        LoadStudentsCommand = new RelayCommand<GroupModel>(LoadStudents);
        DeleteStudentCommand = new RelayCommand<StudentModel>(DeleteStudent);
        UpdateStudentCommand = new RelayCommand<StudentModel>(UpdateStudent);
        AddStudentCommand = new RelayCommand(AddStudent);
        PickRandomStudentCommand = new RelayCommand(PickRandomStudent);
    }

    private void LoadStudents(GroupModel? groupModel)
    {
        if (groupModel == null)
            return;

        _currentGroup = groupModel;
        _students.Clear();

        IReadOnlyCollection<Student> students = _studentService.GetStudents(groupModel.Id);
        foreach (var student in students)
        {
            _students.Add(new StudentModel(student));
        }
    }
    private void DeleteStudent(StudentModel? studentModel)
    {
        if (studentModel == null)
            return;

        _studentService.DeleteStudent(studentModel.Id);
        _students.Remove(studentModel);
    }
    private void UpdateStudent(StudentModel? studentModel)
    {
        if (studentModel == null || _currentGroup == null)
            return;

        StudentDialogResult? result = _updateDialogService.ShowUpdateStudentDialog(studentModel);

        if (result is not null)
        {
            StudentMapper.UpdateModelFromDialogResult(result, studentModel);
            Student student = StudentMapper.ToDomain(studentModel, _currentGroup.Id);

            _studentService.UpdateStudent(student);
        }
    }
    private void AddStudent()
    {
        if (_currentGroup == null)
            return;

        StudentDialogResult? result = _addDialogService.ShowAddStudentDialog();

        if (result is not null)
        {
            Student student = StudentMapper.ToDomain(result, _currentGroup.Id);

            _studentService.AddStudent(student);
            _students.Add(new StudentModel(student));
        }
    }

    private void PickRandomStudent()
    {        
        if (_currentGroup == null)
            return;

        List<int> available = _students.Where(student => !student.Excluded)
                                       .Select(student => student.Id)
                                       .ToList();

        int? pickedId = _studentPickerService.PickRandom(available);

        if(pickedId is not null)
        {
            StudentModel? pickedStudent = _students.FirstOrDefault(student => student.Id == pickedId);

            if(pickedStudent is not null)
                pickedStudent.Excluded = true;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
