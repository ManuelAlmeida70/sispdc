using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Especialidade.Add;

public class AddEspecialidade : IAddEspecialidade
{
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public AddEspecialidade(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }
    public async Task  Execute(EspecialidadeModel especialidadeModel)
    {
        await _especialidadeRepository.Add(especialidadeModel);
    }
}
