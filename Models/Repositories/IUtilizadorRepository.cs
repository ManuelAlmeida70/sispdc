using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IUtilizadorRepository
{
    Task<UtilizadorModel> Add(UtilizadorModel utilizadorModel);
    Task<bool> EmailExist(string email);

    Task<UtilizadorModel> GetUitlizadorByEmail(string? email);

    Task Eliminar(UtilizadorModel utilizadorModel);

    Task<bool> EliminarById(int id);
}
