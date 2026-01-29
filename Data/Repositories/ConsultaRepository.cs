using Microsoft.EntityFrameworkCore;
using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Data.Repositories;

public class ConsultaRepository : IConsultaRepository
{
    private readonly DbSisPdcContext _context;

    public ConsultaRepository(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task Add(ConsultaModel consulta)
    {
        await _context.AddAsync(consulta);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ConsultaModel>> GetAll()
    {
        return await _context.Consultas.ToListAsync();
    }

    public async Task<ConsultaModel> GetByIdPessoaAdministrativa(string? id)
    {
        var cons = await _context.Consultas.FirstOrDefaultAsync(consulta => consulta.IdPessoaClinica == id);

        return cons!;
    }

    public async Task<ConsultaModel> GetByIdUtente(string? id)
    {
        var cons = await _context.Consultas.FirstOrDefaultAsync(consulta => consulta.IdUtente == id);

        return cons!;
    }
}
