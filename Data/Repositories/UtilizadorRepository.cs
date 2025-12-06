using Microsoft.EntityFrameworkCore;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Data.Repositories;

public class UtilizadorRepository : IUtilizadorRepository
{
    private readonly DbSisPdcContext _dbSisPdcContext;
    public UtilizadorRepository(DbSisPdcContext dbSisPdcContext)
    {
        _dbSisPdcContext = dbSisPdcContext;
    }
    public async Task<UtilizadorModel> Add(UtilizadorModel utilizadorModel)
    {
        var result = await _dbSisPdcContext.AddAsync(utilizadorModel);

        await _dbSisPdcContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> EmailExist(string email)
    {
        var result = await _dbSisPdcContext.Utilizadores.AnyAsync(x => x.Email == email);

        return result;
    }
}
