using Microsoft.EntityFrameworkCore;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Data.Repositories;

public class PessoaAdministrativaRepository : IPessoaAdministrativaRepository
{
    private readonly DbSisPdcContext _context;
    public PessoaAdministrativaRepository(DbSisPdcContext context)
    {
        _context = context;
    }
    public async Task<PessoaAdministrativaModel> Add(PessoaAdministrativaModel model)
    {
        var result = await _context.AddAsync(model);

        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<List<PessoaAdministrativaModel>> GetAll()
    {
        return await _context.PessoaAdministrativas.ToListAsync();
    }
}
