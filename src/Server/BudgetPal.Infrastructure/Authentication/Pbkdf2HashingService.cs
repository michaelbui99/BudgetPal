using System.Security.Cryptography;
using Core.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BudgetPal.Infrastructure.Authentication;

public class Pbkdf2HashingService : IHashingService
{
    private const int _iterations = 350000;
    private const int _keySize = 64;

    public string Hash(string password, byte[] salt)
    {
        string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            salt,
            KeyDerivationPrf.HMACSHA256,
            _iterations,
            _keySize
        ));
        return hash;
    }
}