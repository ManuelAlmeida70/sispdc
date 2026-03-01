using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Consulta.AtribuirMedico;

public class AtribuirConsultaMedico : IAtribuirConsultaMedico
{
    private readonly IConsultaRepository _consultaRepository;

    public AtribuirConsultaMedico(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<ResponseModel<bool>> Execute(int idConsulta, string idPessoaClinica)
    {
        if (idConsulta <= 0)
            return new ResponseModel<bool> { Status = false, Message = "Consulta inválida.", Data = false };

        if (string.IsNullOrWhiteSpace(idPessoaClinica))
            return new ResponseModel<bool> { Status = false, Message = "Selecione um médico.", Data = false };

        var result = await _consultaRepository.AtribuirMedico(idConsulta, idPessoaClinica);

        if (!result)
            return new ResponseModel<bool> { Status = false, Message = "Consulta não encontrada.", Data = false };

        return new ResponseModel<bool> { Status = true, Message = "Médico atribuído com sucesso!", Data = true };
    }
}
