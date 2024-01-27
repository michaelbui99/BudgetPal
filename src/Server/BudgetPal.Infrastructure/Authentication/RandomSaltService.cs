using System.Security.Cryptography;
using Core.Authentication;

namespace BudgetPal.Infrastructure.Authentication;

public class RandomSaltService: ISaltService
{
    public byte[] GetSalt(int keySize)
    {
        return RandomNumberGenerator.GetBytes(keySize);
    }
}