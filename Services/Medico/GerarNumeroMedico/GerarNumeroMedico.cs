using Microsoft.EntityFrameworkCore;
using SisPDC.Data;
using SisPDC.Services.Utente.GerarNumeroUtente;

namespace SisPDC.Services.Medico.GerarNumeroMedico;

public class GerarNumeroMedico : IGerarNumeroMedico
{
    private readonly DbSisPdcContext _context;
    private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

    public GerarNumeroMedico(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task<string> GerarPessoaClinico()
    {
        await _semaphoreSlim.WaitAsync();

        try
        {
            using (var transition = await _context.Database.BeginTransactionAsync())
            {
                int ano = DateTime.Now.Year;

                var ultimoNumero = await _context.PessoaClinicas
                    .Where(u => u.IdPessoaClinica.StartsWith($"PC{ano}"))
                    .OrderByDescending(u => u.IdPessoaClinica)
                    .Select(u => u.IdPessoaClinica)
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

                string novoNumero = $"PC{ano}{proximoNumero:D6}";

                await transition.CommitAsync();

                return novoNumero;
            }
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
}
