using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IPessoaClinicaRepository
{
    Task<PessoaAdministrativaModel> Add(PessoaAdministrativaModel model);
}
