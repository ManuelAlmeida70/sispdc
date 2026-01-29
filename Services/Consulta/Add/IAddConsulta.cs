using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Consulta.Add;

public interface IAddConsulta
{
    Task<ResponseModel<ConsultaDTO>> Execute(ConsultaDTO consultaDTO);
}
