using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Consulta.GetAll;

public interface IGetAllConsulta
{
    Task<List<ConsultaModel>> Execute();
}
