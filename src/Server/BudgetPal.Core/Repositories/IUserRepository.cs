using Core.Models;

namespace Core.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
}