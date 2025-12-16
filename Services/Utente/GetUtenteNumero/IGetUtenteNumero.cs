namespace SisPDC.Services.Utente.GetUtenteNumero;

public interface IGetUtenteNumero
{
    Task<string> GetUtenteNumeroAsync(string email);
}
