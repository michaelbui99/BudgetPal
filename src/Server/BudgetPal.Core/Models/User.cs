using System.Security.Cryptography;
using Core.Models.Common;

namespace Core.Models;

public class User : AuditableEntity
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public byte[] Salt { get; set; } = RandomNumberGenerator.GetBytes(64);
    public DateTimeOffset DateOfBirth { get; set; }
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}