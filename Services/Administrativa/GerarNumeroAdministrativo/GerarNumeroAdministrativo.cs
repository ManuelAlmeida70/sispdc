
using Microsoft.EntityFrameworkCore;
using SisPDC.Data;
using System.Threading;

namespace SisPDC.Services.Administrativa.GerarNumeroAdministrativo;

public class GerarNumeroAdministrativo : IGerarNumeroAdministrativo
{
    private readonly DbSisPdcContext _context;
    private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

    public GerarNumeroAdministrativo(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task<string> GerarPessoaAdministrativo()
    {
        await _semaphoreSlim.WaitAsync();

        try
        {
            using (var transition = await _context.Database.BeginTransactionAsync())
            {
                int ano = DateTime.Now.Year;

                var ultimoNumero = await _context.PessoaAdministrativas
                    .Where(u => u.IdPessoaAdmin.StartsWith($"ADM{ano}"))
                    .OrderByDescending(u => u.IdPessoaAdmin)
                    .Select(u => u.IdPessoaAdmin)
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

                string novoNumero = $"ADM{ano}{proximoNumero:D6}";

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
