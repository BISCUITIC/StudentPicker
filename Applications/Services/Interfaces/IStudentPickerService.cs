namespace Application.Services.Interfaces;

public interface IStudentPickerService
{
    public int? PickRandom(IReadOnlyCollection<int> available);
}

