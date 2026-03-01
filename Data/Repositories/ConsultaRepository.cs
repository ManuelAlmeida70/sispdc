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

    public async Task<bool> AtribuirMedico(int idConsulta, string idPessoaClinica)
    {
        var consulta = await _context.Consultas.FindAsync(idConsulta);
        if (consulta is null)
            return false;

        consulta.IdPessoaClinica = idPessoaClinica;
        consulta.Estado = "Marcado";
        consulta.DataUltimaAtualizacao = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ConsultaModel>> GetAll()
    {
        return await _context.Consultas.ToListAsync();
    }

    public async Task<ConsultaModel> GetById(string? id)
    {
        return await _context.Consultas.FirstAsync(consulta => consulta.IdConsulta.ToString() == id);
    }

    public async Task<ConsultaModel> GetByIdPessoaClinica(string? id)
    {
        var cons = await _context.Consultas.FirstOrDefaultAsync(consulta => consulta.IdPessoaClinica == id);

        return cons!;
    }

    public async Task<List<ConsultaModel>> GetByIdUtenteAll(string? id)
    {
        var cons = await _context.Consultas.Where(consulta => consulta.IdUtente == id).ToListAsync();

        return cons!;
    }

    
}
