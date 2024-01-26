using Core.Models;

namespace Core.Repositories;

public interface IBudgetRepository
{
    public Task AssignAccountToBudget(Guid budgetId, Account account);
    public Task<Budget> CreateNew(Guid userId, string name, ICollection<Account> accounts);
    public Task AddCategoryGroup(Guid budgetId, string name);
    public Task AddCategory(Guid categoryGroupId, string name);
}