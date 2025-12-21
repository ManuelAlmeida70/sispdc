using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IPessoaClinicaRepository
{
    Task<PessoaClinicaModel> Add(PessoaClinicaModel model);
    Task<List<PessoaClinicaModel>> GetAll();
    Task<PessoaClinicaModel> GetByIdMedicos(string? id);
    Task EliminarByIdMedico(PessoaClinicaModel pessoaClinicaModel);
}
