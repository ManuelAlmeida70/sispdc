namespace SisPDC.Services.CriptPassword;

public interface ICriptPassword
{
    void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] SaltHash);
    bool VerifiPassword(string password, byte[] PasswordHash, byte[] SaltHash);
}
