namespace SisPDC.Services.Utente.GerarNumeroUtente;

public interface IGerarNumeroUtente
{
    Task<string> GerarNumeroUtenteAsync();
}
