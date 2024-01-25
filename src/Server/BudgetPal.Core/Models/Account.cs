using Core.Models.Common;

namespace Core.Models;

public class Account : AuditableEntity
{
    public MoneyAmount Balance { get; set; } = MoneyAmount.NewDefault();
    public string Name { get; set; }
}