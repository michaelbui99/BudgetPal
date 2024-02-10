using System.Collections;
using Core.Models;

namespace Application.V1.CreateAccount.Repositories;

public interface IAccountsRepository
{
    Task<IEnumerable<Account>> GetAccountsByUserId(Guid userId);
    Task<Account> AddAccount(Guid userId, Account account);
}