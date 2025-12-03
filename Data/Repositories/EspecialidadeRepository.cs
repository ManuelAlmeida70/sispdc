using Microsoft.EntityFrameworkCore;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Data.Repositories;

public class EspecialidadeRepository : IEspecialidadeRepository
{
    private readonly DbSisPdcContext _dbSisPdcContext;
    public EspecialidadeRepository(DbSisPdcContext dbSisPdcContext)
    {
        _dbSisPdcContext = dbSisPdcContext;
    }
    public async Task Add(EspecialidadeModel especialidadeModel)
    {
        await _dbSisPdcContext.AddAsync(especialidadeModel);
        await _dbSisPdcContext.SaveChangesAsync();
    }

    public async Task DeleteById(EspecialidadeModel especialidadeModel)
    {
        _dbSisPdcContext.Remove(especialidadeModel);
        await _dbSisPdcContext.SaveChangesAsync();
    }

    public async Task<List<EspecialidadeModel>> GetAll()
    {
        return await _dbSisPdcContext.Especialidades.ToListAsync();
    }

    public async Task<EspecialidadeModel> GetById(int? id)
    {
        var result = await _dbSisPdcContext.Especialidades.FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            return null!;

        return result;
    }

    public async Task Update(EspecialidadeModel especialidadeModel)
    {
        _dbSisPdcContext.Especialidades.Update(especialidadeModel);
        await _dbSisPdcContext.SaveChangesAsync();

    }
}
