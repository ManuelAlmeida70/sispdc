using SisPDC.Models.Entities;

namespace SisPDC.Services.Consulta.AtribuirMedico;

public interface IAtribuirConsultaMedico
{
    Task<ResponseModel<bool>> Execute(int idConsulta, string idPessoaClinica);
}