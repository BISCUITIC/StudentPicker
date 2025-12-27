using Application.Services.Interfaces;

namespace Application.Services;

public class StudentPickerService : IStudentPickerService
{   
    private readonly IRandomProvider _random;
    
    public StudentPickerService(IRandomProvider randomProvider)
    {
        _random = randomProvider;    
    }

    public int? PickRandom(IReadOnlyCollection<int> available)
    { 
        return _random.Next(available);
    }
}
