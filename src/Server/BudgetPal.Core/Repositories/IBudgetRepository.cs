using Core.Models;

namespace Core.Repositories;

public interface IBudgetRepository
{
    public Task<Budget> CreateNewAsync(string name, ICollection<Account> accounts);
}