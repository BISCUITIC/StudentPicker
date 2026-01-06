namespace Presentation.ViewModels.Dialogs;

public class GroupDialogViewModel : DialogViewModel
{
    public int Number { get; set; }
    public string Letter { get; set; } = null!;

    protected override bool CanSave()
    {
        if (Number <= 0 || Number >= 12)
        {
            ErrorMessage = "The group number must be in the range from 1 to 11";
            return false;
        }

        if(string.IsNullOrEmpty(Letter) || !char.IsLetter(Letter[0]))
        {
            ErrorMessage = "The group letter must be in the range from A(a) to Z(z)";
            return false;
        }
        
        return true;
    }
}
    