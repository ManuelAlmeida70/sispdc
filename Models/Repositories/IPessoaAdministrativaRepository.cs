using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IPessoaAdministrativaRepository
{
    Task<PessoaAdministrativaModel> Add(PessoaAdministrativaModel model);
    Task<List<PessoaAdministrativaModel>> GetAll();
}
