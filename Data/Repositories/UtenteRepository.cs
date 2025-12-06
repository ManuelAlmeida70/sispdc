using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Data.Repositories;

public class UtenteRepository : IUtenteRepository
{
    private readonly DbSisPdcContext _dbSisPdcContext;

    public UtenteRepository(DbSisPdcContext dbSisPdcContext)
    {
        _dbSisPdcContext = dbSisPdcContext;
    }
    public async Task<UtenteModel> Add(UtenteModel utenteModel)
    {
        var result = await _dbSisPdcContext.AddAsync(utenteModel);
        
        await _dbSisPdcContext.SaveChangesAsync();

        return result.Entity;
    }
}
