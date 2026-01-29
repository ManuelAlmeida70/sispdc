using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Consulta.Add;

public class AddConsulta : IAddConsulta
{
    private readonly IConsultaRepository _consultaRepository;

    public AddConsulta(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }
    public async Task<ResponseModel<ConsultaDTO>> Execute(ConsultaDTO consultaDTO)
    {
        ResponseModel<ConsultaDTO> response = new ResponseModel<ConsultaDTO>();

        try
        {
            var consulta = new ConsultaModel()
            {
                Observacoes = consultaDTO.Observacoes,
                IdUtente = consultaDTO.IdUtente,
                DataConsulta = consultaDTO.DataConsulta,
                DataCriacao = DateTime.Now,
                DataUltimaAtualizacao = DateTime.Now,
                Descricao = consultaDTO.Descricao,
                Estado = consultaDTO.Estado,
                HoraConsulta = consultaDTO.HoraConsulta,
            };

            await _consultaRepository.Add(consulta);

            response.Data = consultaDTO;
            response.Message = "Consulta cadastrada com sucesso";

            return response;
        }
        catch (Exception ex)
        {
            response.Data = null!;
            response.Message = ex.Message;

            return response;
        }
    }
}
