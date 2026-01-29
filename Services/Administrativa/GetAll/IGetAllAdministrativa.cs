using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Administrativa.GetAll;

public interface IGetAllAdministrativa
{
    Task<List<PessoaAdministrativaModel>> Execute();
}
