namespace Application.Exceptions;

public class GroupNotFoundException : Exception
{
    public GroupNotFoundException()
       : base($"No such group") { }
}
