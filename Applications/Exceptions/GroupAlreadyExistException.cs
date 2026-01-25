namespace Application.Exceptions;

public class GroupAlreadyExistException : Exception
{
    public GroupAlreadyExistException(int groupNumber, char groupLetter)
        : base($"Group {groupNumber}{groupLetter} already exists.") { }
}
