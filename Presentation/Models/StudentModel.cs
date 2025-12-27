using Domain.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.Models;

public class StudentModel : INotifyPropertyChanged
{
    private readonly int _id;
    private string _name = null!;
    private string _secondName = null!;
    private bool _excluded;
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

    public bool Excluded
    {
        get => _excluded;
        set { _excluded = value; OnPropertyChanged(); }
    }

    public StudentModel(Student domain)
    {
        Id = domain.Id;
        Name = domain.Name;
        SecondName = domain.SecondName;
        Excluded = false;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
