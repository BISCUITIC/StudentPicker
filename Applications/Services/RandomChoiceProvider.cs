using Application.Services.Interfaces;

namespace Application.Services;

public class RandomChoiceProvider : IRandomProvider
{
    private readonly Random _random;

    public RandomChoiceProvider()
    {
        _random = new Random();
    }

    public int? Next(IReadOnlyCollection<int> selection)
    {
        List<int> available  = selection.ToList();        

        if(available.Count == 0)
            return null;

        int randomIndex = _random.Next(0, available.Count);

        return available[randomIndex];
    }
}
