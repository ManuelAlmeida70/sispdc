using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Consulta.GetAll;

public class GetAllConsulta : IGetAllConsulta
{
    private readonly IConsultaRepository _consulta;

    public GetAllConsulta(IConsultaRepository consulta)
    {
        _consulta = consulta;
    }

    public async Task<List<ConsultaModel>> Execute()
    {
        var consultas = new List<ConsultaModel>();

        consultas = await _consulta.GetAll();

        return consultas;
    }
}
