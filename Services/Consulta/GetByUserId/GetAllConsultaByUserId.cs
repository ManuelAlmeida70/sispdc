using AutoMapper;
using SisPDC.Data.Repositories;
using SisPDC.DTOs;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Consulta.GetByUserId;

public class GetAllConsultaByUserId : IGetAllConsultaByUserId
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IMapper _mapper;
    public GetAllConsultaByUserId(IConsultaRepository consultaRepository, IMapper mapper)
    {
        _consultaRepository = consultaRepository;
        _mapper = mapper;
    }
    public async Task<List<ConsultaDTO>> Execute(string id)
    {
        var consultas = await _consultaRepository.GetByIdUtenteAll(id);
        List<ConsultaDTO> result = new List<ConsultaDTO>();

        foreach (var consulta in consultas)
        {
            var data = _mapper.Map<ConsultaDTO>(consulta);
            result.Add(data);
        }

        return result;
    }
}
