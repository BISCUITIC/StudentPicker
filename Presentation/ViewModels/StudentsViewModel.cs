using Application.Services;
using Domain.Entities;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels;

public class StudentsViewModel
{
    private readonly StudentProvider _studentProvider;
    private readonly ObservableCollection<Student> _students;

    public ObservableCollection<Student> Students { get => _students; }

    public StudentsViewModel(StudentProvider studentProvider)
    {
        _studentProvider = studentProvider;
        _students = new ObservableCollection<Student>();
    }

    public void LoadStudents(Group group)
    {        
        IReadOnlyCollection<Student> students = _studentProvider.GetStudents(group);
        foreach (var student in students)
        {
            _students.Add(student);
        }
    }
}
