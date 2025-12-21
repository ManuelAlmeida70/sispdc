using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Medico.GetById;

public class GetByIdMedico : IGetByIdMedico
{
    private readonly IPessoaClinicaRepository _pessoaClinicaRepository;

    public GetByIdMedico(IPessoaClinicaRepository pessoaClinicaRepository)
    {
        _pessoaClinicaRepository = pessoaClinicaRepository;
    }
    public async Task<PessoaClinicaModel> Execute(string? id)
    {
        var pessoaClinico = await _pessoaClinicaRepository.GetByIdMedicos(id);

        return pessoaClinico;
    }
}
