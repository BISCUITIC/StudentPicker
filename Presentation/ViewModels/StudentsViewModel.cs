using Application.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.Models;
using Presentation.Services;
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
    private readonly IAddStudentDialogService _studentAddDialogService;    
    private readonly IUpdateStudentDialogService _updateStudentDialogService;

    private readonly ObservableCollection<StudentModel> _students;

    private GroupModel? _currentGroup;

    public ObservableCollection<StudentModel> Students { get => _students; }

    public ICommand LoadStudentsCommand { get; }
    public ICommand DeleteStudentCommand { get; }
    public ICommand UpdateStudentCommand { get; }
    public ICommand AddStudentCommand { get; }

    public StudentsViewModel(IStudentService studentProvider,                              
                             IAddStudentDialogService studentAddDialogService)
    {
        _studentService = studentProvider;        
        _studentAddDialogService = studentAddDialogService;

        _students = new ObservableCollection<StudentModel>();

        LoadStudentsCommand = new RelayCommand<GroupModel>(LoadStudents);
        DeleteStudentCommand = new RelayCommand<StudentModel>(DeleteStudent);
        UpdateStudentCommand = new RelayCommand<StudentModel>(UpdateStudent);
        AddStudentCommand = new RelayCommand(AddStudent);
    }

    public void LoadStudents(GroupModel? groupModel)
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
    public void DeleteStudent(StudentModel? studentModel)
    {
        if (studentModel == null)
            return;        

        _studentService.DeleteStudent(studentModel.Id);
        _students.Remove(studentModel);
    }
    public void UpdateStudent(StudentModel? studentModel)
    {        
        if (studentModel == null)
            return;

        StudentDialogResult? result = _studentAddDialogService.ShowAddStudentDialog();

        if (result is not null)
        {
            Student studentDomain = _studentService.GetStudent(studentModel.Id);
            StudentMapper.UpdateDomainFromModel(studentModel, studentDomain);
            _studentService.UpdateStudent(studentDomain);            
        }
    }
    public void AddStudent()
    {
        if (_currentGroup == null)
            return;

        StudentDialogResult? result = _studentAddDialogService.ShowAddStudentDialog();

        if (result is not null)
        {            
            Student student = StudentMapper.ToDomain(_currentGroup.Id, result);

            _studentService.AddStudent(student);
            _students.Add(new StudentModel(student));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
