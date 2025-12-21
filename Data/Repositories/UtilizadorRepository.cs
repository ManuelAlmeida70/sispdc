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

    public async Task Eliminar(UtilizadorModel utilizadorModel)
    {
        _dbSisPdcContext.Remove(utilizadorModel);

        await _dbSisPdcContext.SaveChangesAsync();
    }

    public async Task<bool> EmailExist(string email)
    {
        var result = await _dbSisPdcContext.Utilizadores.AnyAsync(x => x.Email == email);

        return result;
    }

    public Task<UtilizadorModel> GetUitlizadorByEmail(string? email)
    {
        var result = _dbSisPdcContext.Utilizadores.FirstOrDefaultAsync(x => x.Email == email);

        return result!;
    }

    public async Task<bool> EliminarById(int id)
    {
        var utilizador = await _dbSisPdcContext.Utilizadores
            .FirstOrDefaultAsync(x => x.IdUtilizador == id);

        if (utilizador == null)
            return false; // Retorna false se não encontrar

        _dbSisPdcContext.Remove(utilizador);
        await _dbSisPdcContext.SaveChangesAsync();
        return true; // Retorna true se eliminou com sucesso
    }
}
