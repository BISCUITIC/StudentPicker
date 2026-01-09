using Application.UseCases.Groups.DTO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.Models;

public class GroupModel : INotifyPropertyChanged
{
    private readonly int _id;
    private int _number;
    private char _letter;

    public int Id
    {
        get => _id;
        init => _id = value;
    }
    public int Number
    {
        get => _number;
        set { _number = value; OnPropertyChanged(); }
    }
    public char Letter
    {
        get => _letter;
        set { _letter = value; OnPropertyChanged(); }
    }

    public GroupModel(GroupDTO groupDTO)
    {
        Id = groupDTO.Id;
        Number = groupDTO.Number;
        Letter = groupDTO.Letter;
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
