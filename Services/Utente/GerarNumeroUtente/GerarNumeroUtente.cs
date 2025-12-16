
using Microsoft.EntityFrameworkCore;
using SisPDC.Data;

namespace SisPDC.Services.Utente.GerarNumeroUtente;

public class GerarNumeroUtente : IGerarNumeroUtente
{
    private readonly DbSisPdcContext _context;
    private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1); 
    public GerarNumeroUtente(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task<string> GerarNumeroUtenteAsync()
    {
        await _semaphoreSlim.WaitAsync();

        try
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                int ano = DateTime.Now.Year;

                var ultimoNumero = await _context.Utentes
                    .Where(u => u.IdUtente.StartsWith($"UT{ano}"))
                    .OrderByDescending(u => u.IdUtente)
                    .Select(u => u.IdUtente)
                    .FirstOrDefaultAsync();

                int proximoNumero = 1;

                if (!string.IsNullOrEmpty(ultimoNumero))
                {
                    string numeroSequencial = ultimoNumero.Substring(6);
                    if (int.TryParse(numeroSequencial, out int numeroAtual))
                    {
                        proximoNumero = numeroAtual + 1;
                    }
                }

                string novoNumero = $"UT{ano}{proximoNumero:D6}";


                await transaction.CommitAsync();

                return novoNumero;
            }
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
}
