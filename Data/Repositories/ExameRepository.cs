using Microsoft.EntityFrameworkCore;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Data.Repositories;

public class ExameRepository : IExameRepository
{
    private readonly DbSisPdcContext _context;

    public ExameRepository(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task Add(ExamesModel exame)
    {
        await _context.Exames.AddAsync(exame);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ExamesModel>> GetAll()
    {
        return await _context.Exames
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<IEnumerable<ExamesModel>> GetAllByIdMedico(string idMedico)
    {
        return await _context.Exames
        .AsNoTracking()
        .Where(e => e.IdPessoaClinica == idMedico && e.Ativo == 1)
        .Include(e => e.PessoaClinica)
            .ThenInclude(pc => pc.Especialidade)
        .OrderByDescending(e => e.DataRequisicao)
        .ToListAsync();
    }

    public async Task<IEnumerable<ExamesModel>> GetAllByIdUtente(string idUtente)
    {
        return await _context.Exames
        .AsNoTracking()
        .Where(e => e.IdUtente == idUtente && e.Ativo == 1)
        .Include(e => e.PessoaClinica)
            .ThenInclude(pc => pc.Especialidade)
        .OrderByDescending(e => e.DataRequisicao)
        .ToListAsync();
    }
}
