using Core.Models;
using Core.Models.Common;

namespace API.Controllers.V1.Dtos;

public class ReadCreatedUserDto: AuditableEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = "";
    public DateTimeOffset? DateOfBirth { get; set; }
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}