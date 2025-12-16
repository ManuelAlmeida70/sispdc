
using Microsoft.EntityFrameworkCore;
using SisPDC.Data;

namespace SisPDC.Services.Medico.GetPessoaMedicoNumero;

public class GetNumeroMedico : IGetNumeroMedico
{
    private readonly DbSisPdcContext _context;

    public GetNumeroMedico(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task<string> GetNumeroPessoaMedico(string email)
    {
        return await _context.PessoaClinicas.
            Where(u => u.Email == email)
            .Select(u => u.IdPessoaClinica)
            .SingleAsync();
    }
}
