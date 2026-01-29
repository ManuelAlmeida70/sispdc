using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Administrativa.Add;

public interface IAddAdministrativa
{
    Task<ResponseModel<PessoaAdministrativaModel>> Execute(PessoaAdministrativasDTO administrativasDTO);
}
