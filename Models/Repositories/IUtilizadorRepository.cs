using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IUtilizadorRepository
{
    Task<UtilizadorModel> Add(UtilizadorModel utilizadorModel);
    Task<bool> EmailExist(string email);
}
