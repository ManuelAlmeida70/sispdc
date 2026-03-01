using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Exames.Add;

public interface IAddExame
{
    Task<ResponseModel<CriarExameDTO>> Execute(CriarExameDTO exameDTO);
}
