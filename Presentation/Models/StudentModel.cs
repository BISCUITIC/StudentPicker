using Domain.Entities;
using System.ComponentModel;

namespace Presentation.Models;

public class StudentModel : INotifyPropertyChanged
{
    private readonly Student _domain;

    public int Id { get => _domain.Id; }
    public string Name
    {
        get => _domain.Name;
        set { _domain.UpdateName(value); OnPropertyChanged(); }
    }
    public string SecondName
    {
        get => _domain.SecondName;
        set { _domain.UpdateSecondName(value); OnPropertyChanged(); }
    }

    public StudentModel(Student domain)
    {
        _domain = domain;
    }

    public Student AsStudent()
    {
        return _domain;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
