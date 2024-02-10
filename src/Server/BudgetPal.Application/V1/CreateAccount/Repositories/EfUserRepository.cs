using BudgetPal.Infrastructure.Data;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.V1.CreateAccount.Repositories;

public class EfUserRepository : IUserRepository
{
    private readonly BudgetPalContext _context;

    public EfUserRepository(BudgetPalContext context)
    {
        _context = context;
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _context.Users
            .Include(user => user.Accounts)
            .SingleOrDefaultAsync(user => user.Id == id);
    }
}