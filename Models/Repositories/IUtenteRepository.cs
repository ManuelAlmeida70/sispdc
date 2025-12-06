using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IUtenteRepository
{
    Task<UtenteModel> Add(UtenteModel utenteModel);
}
