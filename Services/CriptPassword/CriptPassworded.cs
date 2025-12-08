using System.Security.Cryptography;

namespace SisPDC.Services.CriptPassword;

public class CriptPassworded : ICriptPassword
{
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] saltHash)
    {
        using (var hmac = new HMACSHA512())
        {
            saltHash = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public bool VerifiPassword(string password, byte[] PasswordHash, byte[] SaltHash)
    {
        using (var hmac = new HMACSHA512(SaltHash))
        {
            var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computerHash.SequenceEqual(PasswordHash);
        }
    }
}
