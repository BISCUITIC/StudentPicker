using Application.Services;
using Domain.Entities;
using Presentation.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

namespace Presentation.ViewModels;

public class StudentsViewModel
{
    private readonly StudentService _studentService;
    private readonly ObservableCollection<StudentModel> _students;

    public ObservableCollection<StudentModel> Students { get => _students; }

    public StudentsViewModel(StudentService studentProvider)
    {
        _studentService = studentProvider;
        _students = new ObservableCollection<StudentModel>();

        _students.CollectionChanged += Students_CollectionChanged;
    }

    public void LoadStudents(int groupId)
    {
        _students.Clear();
        IReadOnlyCollection<Student> students = _studentService.GetStudents(groupId);
        foreach (var student in students)
        {
            _students.Add(new StudentModel(student));
        }
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

    private void Student_PropertyChanged(object? sender, PropertyChangedEventArgs eventArgs)
    {
        if (eventArgs.PropertyName is not null)
        {
            StudentModel? studentModel = sender as StudentModel;
            if (studentModel is not null)
            {
                var studentDomain = _studentService.GetStudent(studentModel.Id);
                StudentMapper.ToDomain(studentModel, studentDomain);                
                _studentService.UpdateStudent(studentDomain);
            }
        }
    }
}
