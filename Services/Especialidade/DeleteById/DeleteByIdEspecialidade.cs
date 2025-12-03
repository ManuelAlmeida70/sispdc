using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Especialidade.DeleteById;

public class DeleteByIdEspecialidade : IDeleteByIdEspecialidade
{
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public DeleteByIdEspecialidade(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }
    public async Task Execute(EspecialidadeModel especialidadeModel)
    {
        await _especialidadeRepository.DeleteById(especialidadeModel);
    }
}
