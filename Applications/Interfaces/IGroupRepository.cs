using Domain.Entities;

namespace Application.Interfaces;

public interface IGroupRepository
{
    Group Get(int groupNumber, char groupLetter);
}
