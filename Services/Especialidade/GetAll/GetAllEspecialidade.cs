using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Especialidade.GetAll;

public class GetAllEspecialidade : IGetAllEspecialidade
{
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public GetAllEspecialidade(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }
    public async Task<List<EspecialidadeModel>> Execute()
    {
        List<EspecialidadeModel> especialidades = await _especialidadeRepository.GetAll();

        return especialidades;
    }
}
