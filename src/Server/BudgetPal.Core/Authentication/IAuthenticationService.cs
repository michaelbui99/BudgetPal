using Core.Models;

namespace Core.Authentication;

public interface IAuthenticationService
{
    User? AuthenticateUser(User user);
    
    // TODO: Rethink this abstraction, seems pretty leaky...
    string GenerateToken(User user);
}
