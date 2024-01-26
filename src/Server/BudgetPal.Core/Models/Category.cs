using Core.Models.Common;

namespace Core.Models;

public class Category: AuditableEntity
{
    public string Name { get; set; }
    public Target Target { get; set; }
    public MoneyAmount AssignedAmount { get; set; }
}