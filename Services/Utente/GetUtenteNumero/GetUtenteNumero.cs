using Microsoft.EntityFrameworkCore;
using SisPDC.Data;

namespace SisPDC.Services.Utente.GetUtenteNumero;

public class GetUtenteNumero : IGetUtenteNumero
{
    private readonly DbSisPdcContext _context;

    public GetUtenteNumero(DbSisPdcContext context)
    {
        _context = context;
    }

    public async Task<string> GetUtenteNumeroAsync(string email)
    {
        return await _context.Utentes
            .Where(u => u.Email == email)
            .Select(u => u.IdUtente)
            .SingleAsync();
    }
}