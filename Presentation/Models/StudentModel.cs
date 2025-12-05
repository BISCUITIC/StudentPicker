using Domain.Entities;
using System.ComponentModel;

namespace Presentation.Models;

public class StudentModel : INotifyPropertyChanged
{
    private readonly int _id;
    private string _name = null!;
    private string _secondName = null!;

    public int Id
    {
        get => _id;
        init { _id = value; }
    }
    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(); }
    }
    public string SecondName
    {
        get => _secondName;
        set { _secondName = value; OnPropertyChanged(); }
    }

    public StudentModel(Student domain)
    {
        Id = domain.Id;
        Name = domain.Name;
        SecondName = domain.SecondName;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
