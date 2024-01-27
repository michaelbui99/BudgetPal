using Core.Models;

namespace Core.Repositories;

public interface IAccountRepository
{
    public Task<Account> AddNew(User user, Account account);
    public Task UpdateBalance(Guid accountId, double newBalance);
}