namespace Core.Models.Common;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}