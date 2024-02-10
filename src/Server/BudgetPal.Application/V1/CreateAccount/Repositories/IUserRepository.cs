using Core.Models;

namespace Application.V1.CreateAccount.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(Guid id);
}