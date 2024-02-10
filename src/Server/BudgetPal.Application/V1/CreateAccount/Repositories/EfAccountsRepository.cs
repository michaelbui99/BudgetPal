using BudgetPal.Infrastructure.Data;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.V1.CreateAccount.Repositories;

public class EfAccountsRepository : IAccountsRepository
{
    private readonly BudgetPalContext _context;

    public EfAccountsRepository(BudgetPalContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> GetAccountsByUserId(Guid userId)
    {
        var user = await _context.Users.Include(user => user.Accounts).FirstOrDefaultAsync(user => user.Id == userId);
        return user is null ? new List<Account>() : user.Accounts;
    }

    public async Task<Account> AddAccount(Guid userId, Account account)
    {
        var user = await _context.Users.Include(user => user.Accounts).SingleOrDefaultAsync(user => user.Id == userId);
        user?.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }
}