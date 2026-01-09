using Application.UseCases.Students.DTO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.Models;

public class StudentModel : INotifyPropertyChanged
{
    private readonly int _id;
    private string _name = string.Empty;
    private string _secondName = string.Empty;

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

    public StudentModel(StudentDTO studentDTO)
    {
        Id = studentDTO.Id;
        Name = studentDTO.Name;
        SecondName = studentDTO.SecondName;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
