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
    public async Task<PessoaAdministrativaModel> Add(PessoaAdministrativaModel model)
    {
        var result = await _context.PessoaAdministrativas.AddAsync(model);

        if (result is null)
            return null!;

        await _context.SaveChangesAsync();

        return model;
    }
}
