using BudgetPal.Infrastructure.Data;
using Core.Models;

namespace Application.V1.CreateUser.Repositories;

public class EfCreateUserRepository: ICreateUserRepository
{
    private readonly BudgetPalContext _context;

    public EfCreateUserRepository(BudgetPalContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}