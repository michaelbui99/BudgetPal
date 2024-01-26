using Core.Exceptions;
using Core.Models;

namespace Core.Repositories;

public interface IBudgetRepository
{
    /// <summary>
    /// Assigns an account to budget.
    /// </summary>
    /// <param name="budgetId">ID (uuid) of the budget</param>
    /// <param name="account">Account to be assigned</param>
    /// <exception cref="NotFoundException">If no budget with provided id exists.</exception>
    public Task AssignAccountToBudget(Guid budgetId, Account account);
    public Task<Budget> CreateNew(Guid userId, string name, ICollection<Account> accounts);
    public Task AddCategoryGroup(Guid budgetId, string name);
    public Task AddCategory(Guid categoryGroupId, string name);
}