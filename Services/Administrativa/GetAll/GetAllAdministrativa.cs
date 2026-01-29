using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;
using System.Collections.Generic;

namespace SisPDC.Services.Administrativa.GetAll;

public class GetAllAdministrativa : IGetAllAdministrativa
{
    private readonly IPessoaAdministrativaRepository _administrativaRepository;

    public GetAllAdministrativa(IPessoaAdministrativaRepository administrativaRepository)
    {
        _administrativaRepository = administrativaRepository;
    }
    public async Task<List<PessoaAdministrativaModel>> Execute()
    {
        try
        {
            List<PessoaAdministrativaModel> pessoas = await _administrativaRepository.GetAll();

            return pessoas;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
