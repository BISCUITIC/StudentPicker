using Application.Services.Interfaces;

namespace Application.Services;

public class RandomChoiceProvider : IRandomProvider
{
    public int? Next(IReadOnlyCollection<int> selection)
    {        
        if (selection.Count == 0)
            return null;
        
        int randomIndex = Random.Shared.Next(selection.Count);
        
        return selection.ElementAt(randomIndex);
    }
}
