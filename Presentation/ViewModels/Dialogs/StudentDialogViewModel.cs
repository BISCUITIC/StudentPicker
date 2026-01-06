namespace Presentation.ViewModels.Dialogs;

public class StudentDialogViewModel : DialogViewModel
{
    public string Name { get; set; } = null!;
    public string SecondName { get; set; } = null!;

    protected override bool CanSave()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            ErrorMessage = "Enter the student's name";
            return false;
        }
        if (string.IsNullOrWhiteSpace(SecondName))
        {
            ErrorMessage = "Enter the student's last name";
            return false;
        }

        return true;
    }
}
