using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Especialidade.GetById;

public class GetByIdEspecialidade : IGetByIdEspecialidade
{
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public GetByIdEspecialidade(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }
    public Task<EspecialidadeModel> Execute(int? id)
    {
        var result = _especialidadeRepository.GetById(id);

        if (result is null) 
            return null!;

        return result;
    }
}
