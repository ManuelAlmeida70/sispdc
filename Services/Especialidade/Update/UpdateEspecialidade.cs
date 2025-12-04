using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Especialidade.Update;

public class UpdateEspecialidade : IUpdateEspecialidade
{
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public UpdateEspecialidade(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }
    public async Task Execute(EspecialidadeModel especialidadeModel)
    {
        var especialidade = await _especialidadeRepository.GetById(especialidadeModel.Id);

        especialidade.Descricao = especialidadeModel.Descricao;

        await _especialidadeRepository.Update(especialidade);
    }
}
