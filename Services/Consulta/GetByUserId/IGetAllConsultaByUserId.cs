using AutoMapper;
using SisPDC.DTOs;

namespace SisPDC.Services.Consulta.GetByUserId;

public interface IGetAllConsultaByUserId
{
    Task<List<ConsultaDTO>> Execute(string id);
}
