using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Medico.GetAll;

public class GetAllMedicos : IGetAllMedicos
{
    private readonly IPessoaClinicaRepository _pessoaClinicaRepository;

    public GetAllMedicos(IPessoaClinicaRepository pessoaClinicaRepository)
    {
        _pessoaClinicaRepository = pessoaClinicaRepository;
    }

    public async Task<List<PessoaClinicaModel>> Execute()
    {
        List<PessoaClinicaModel> pessoaClinicas = await _pessoaClinicaRepository.GetAll();

        return pessoaClinicas;
    }
}
