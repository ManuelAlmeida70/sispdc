namespace SisPDC.Services.Utilizador.VerifyEmail;

public interface IVerifyEmail
{
    Task<bool> Execute(string email);
}
