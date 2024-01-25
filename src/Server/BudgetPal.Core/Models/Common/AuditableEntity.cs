namespace Core.Models.Common;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset LastModified { get; set; } = DateTimeOffset.UtcNow;
    public string? LastModifiedBy { get; set; }
    public string? CreatedBy { get; set; }

    public void RegisterModification(string? by)
    {
        LastModified = DateTimeOffset.UtcNow;
        LastModifiedBy = by ?? "Unknown";
    }
}