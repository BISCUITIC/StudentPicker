using Application.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace Presentation.ViewModels;

public class StudentsViewModel
{
    private readonly IStudentService _studentService;
    private readonly IGroupService _groupService;
    private readonly ObservableCollection<StudentModel> _students;

    private GroupModel? _currentGroup;

    public ObservableCollection<StudentModel> Students { get => _students; }

    public ICommand LoadStudentsCommand { get; }
    public ICommand DeleteStudentCommand { get; }
    public ICommand UpdateStudentCommand { get; }
    public ICommand AddStudentCommand { get; }

    public StudentsViewModel(IStudentService studentProvider, IGroupService groupService)
    {
        _studentService = studentProvider;
        _groupService = groupService;
        _students = new ObservableCollection<StudentModel>();

        LoadStudentsCommand = new RelayCommand<GroupModel>(LoadStudents);
        DeleteStudentCommand = new RelayCommand<StudentModel>(DeleteStudent);
        UpdateStudentCommand = new RelayCommand<StudentModel>(UpdateStudent);
        AddStudentCommand = new RelayCommand(AddStudent);

        _students.CollectionChanged += Students_CollectionChanged;
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

        Student studentDomain = _studentService.GetStudent(studentModel.Id);

        _studentService.DeleteStudent(studentDomain);
        _students.Remove(studentModel);
    }
    public void UpdateStudent(StudentModel? studentModel)
    {
        if (studentModel == null)
            return;

        Student studentDomain = _studentService.GetStudent(studentModel.Id);
        StudentMapper.ToDomain(studentModel, studentDomain);

        _studentService.UpdateStudent(studentDomain);
    }
    public void AddStudent()
    {
        if (_currentGroup == null)
            return;

        Group groupDomain = _groupService.GetGroup(_currentGroup.Id);
        Student student = new Student("", "", groupDomain);

        _studentService.AddStudent(student);
        _students.Add(new StudentModel(student));
    }

    private void Student_PropertyChanged(object? sender, PropertyChangedEventArgs eventArgs)
    {
        if (eventArgs.PropertyName is null)
            return;

        UpdateStudentCommand.Execute(sender as StudentModel);
    }
    private void Students_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs eventArgs)
    {
        if (eventArgs.NewItems != null)
            foreach (StudentModel student in eventArgs.NewItems)
                student.PropertyChanged += Student_PropertyChanged;

        if (eventArgs.OldItems != null)
            foreach (StudentModel student in eventArgs.OldItems)
                student.PropertyChanged -= Student_PropertyChanged;
    }
}
