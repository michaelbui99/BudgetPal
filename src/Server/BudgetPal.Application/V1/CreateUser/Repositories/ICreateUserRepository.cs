using Core.Models;
using Core.Repositories;

namespace Application.V1.CreateUser.Repositories;

public interface ICreateUserRepository
{
    Task<User> CreateUser(User user);
}
