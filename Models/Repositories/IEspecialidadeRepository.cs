using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IEspecialidadeRepository
{
    Task Add(EspecialidadeModel especialidadeModel);

    Task<List<EspecialidadeModel>> GetAll();

    Task<EspecialidadeModel> GetById(int? id);

    Task Update(EspecialidadeModel especialidadeModel);

    Task DeleteById(EspecialidadeModel especialidadeModel);
}
