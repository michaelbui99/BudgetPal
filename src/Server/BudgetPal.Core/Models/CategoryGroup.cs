using Core.Models.Common;

namespace Core.Models;

public class CategoryGroup : AuditableEntity
{
    public IDictionary<string, Category> Categories { get; set; }
    public string Name { get; set; }
}