using Microsoft.EntityFrameworkCore;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Data.Repositories;

public class PessoaClinicaRepository : IPessoaClinicaRepository
{
    private readonly DbSisPdcContext _context;

    public PessoaClinicaRepository(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task<PessoaClinicaModel> Add(PessoaClinicaModel model)
    {
        var result = await _context.PessoaClinicas.AddAsync(model);

        if (result is null)
            return null!;

        await _context.SaveChangesAsync();

        return model;
    }

    public async Task EliminarByIdMedico(PessoaClinicaModel pessoaClinicaModel)
    {
        var medico = _context.PessoaClinicas.Remove(pessoaClinicaModel);

        await _context.SaveChangesAsync();
    }

    public async Task<List<PessoaClinicaModel>> GetAll()
    {
        return await _context.PessoaClinicas.ToListAsync();
    }

    public async Task<PessoaClinicaModel> GetByIdMedicos(string? id)
    {
        var medico = await _context.PessoaClinicas.FirstOrDefaultAsync(x => x.IdPessoaClinica == id);

        return medico;
    }
}
