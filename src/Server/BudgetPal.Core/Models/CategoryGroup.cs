using Core.Models.Common;

namespace Core.Models;

public class CategoryGroup : AuditableEntity
{
    /// <summary>
    /// The amount of money assigned to the category group. The sum of the assigned amounts of the categories
    /// cannot exceed the assigned amount of the category group.
    /// </summary>
    public MoneyAmount AssignedAmount { get; set; }
    /// <summary>
    /// Categories of the category group. All categories must be uniquely named.
    /// </summary>
    public ICollection<Category> Categories { get; set; }
    /// <summary>
    /// Name of the category group. Must be unique. 
    /// </summary>
    public string Name { get; set; }
}