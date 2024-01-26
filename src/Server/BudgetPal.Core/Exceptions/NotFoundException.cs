namespace Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entityType, Guid id) : base(
        $"Entity {entityType} with id {id.ToString()} was not found")

    {
    }
}