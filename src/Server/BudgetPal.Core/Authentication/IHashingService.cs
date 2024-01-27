using System.Security.Cryptography;
using System.Text;

namespace Core.Authentication;

public interface IHashingService
{
    string Hash(string password, byte[] salt);
}