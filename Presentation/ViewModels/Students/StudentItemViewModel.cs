using CommunityToolkit.Mvvm.Input;
using Presentation.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModels.Students;

public class StudentItemViewModel : INotifyPropertyChanged
{
    private readonly StudentModel _student;

    private bool _isExcluded;
    public bool IsExcluded
    {
        get => _isExcluded;
        private set { _isExcluded = value; OnPropertyChanged(); }
    }

    public StudentModel Student { get => _student; }

    public ICommand DeleteStudentCommand { get; }
    public ICommand UpdateStudentCommand { get; }
    public ICommand ToggleExludedCommand { get; }

    public event Action<StudentItemViewModel>? RequestDelete;
    public event Action<StudentItemViewModel>? RequestUpdate;

    public StudentItemViewModel(StudentModel student)
    {
        _student = student;
        _isExcluded = false;

        DeleteStudentCommand = new RelayCommand(DeleteStudent);
        UpdateStudentCommand = new RelayCommand(UpdateStudent);
        ToggleExludedCommand = new RelayCommand(ToggleExluded);
    }

    public void Exclude() => IsExcluded = true;

    public void Include() => IsExcluded = false;

    private void DeleteStudent()
    {
        RequestDelete?.Invoke(this);
    }

    private void UpdateStudent()
    {
        RequestUpdate?.Invoke(this);
    }

    private void ToggleExluded()
    {
        IsExcluded = !IsExcluded;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
