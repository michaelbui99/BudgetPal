using Core.Models.Common;

namespace Core.Models;

public class Budget : AuditableEntity
{
    public string Name { get; set; } = "Unnamed Budget";
    public ICollection<Account> Accounts { get; set; }
}