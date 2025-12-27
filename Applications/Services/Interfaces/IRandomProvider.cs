namespace Application.Services.Interfaces;

public interface IRandomProvider
{
    int? Next(IReadOnlyCollection<int> selection);
}
