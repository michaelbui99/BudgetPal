namespace Core.Authentication;

public interface ISaltService
{
    byte[] GetSalt(int keySize);
}