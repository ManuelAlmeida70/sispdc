using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Consulta.GetById;

public class GetConsultaById : IGetConsultaById
{
    private readonly IConsultaRepository _consultaRepository;

    public GetConsultaById(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }
    public async Task<ResponseModel<ConsultaModel>> Execute(int id)
    {
        var response = new ResponseModel<ConsultaModel>();

        try
        {
            var consulta = await _consultaRepository.GetById(id.ToString());
            if (consulta == null)
            {
                response.Message = "Consulta não encontrada.";
                return response;
            }
            response.Data = consulta;
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = $"Ocorreu um erro ao obter a consulta: {ex.Message}";
            return response;
        }
    }
}
