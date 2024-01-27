using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BudgetPal.Infrastructure.Data;
using Core;
using Core.Authentication;
using Core.Exceptions;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BudgetPal.Infrastructure.Authentication;

public class JwtAuthenticationService : IAuthenticationService
{
    private readonly IHashingService _hashingService;
    private readonly BudgetPalContext _context;

    public JwtAuthenticationService(IHashingService hashingService, BudgetPalContext context)
    {
        _hashingService = hashingService;
        _context = context;
    }

    public User? AuthenticateUser(User user)
    {
        User? authenticatedUser = null;

        var userEntity = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (userEntity is null)
        {
            throw new NotFoundException(nameof(User), user.Id);
        }

        var salt = user.Salt;
        var passwordHash = _hashingService.Hash(user.Password, salt);
        if (passwordHash == userEntity.Password)
        {
            authenticatedUser = userEntity;
        }

        return authenticatedUser;
    }

    public string GenerateToken(User user)
    {
        SymmetricSecurityKey key =
            new(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(EnvironmentVariables.JwtKey) ??
                                       Defaults.DefaultJwtKey));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        var issuer = Environment.GetEnvironmentVariable(EnvironmentVariables.JwtIssuer);
        JwtSecurityToken token = new(issuer, issuer, null, expires: DateTime.UtcNow.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}