using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Utilizador.VerificarSessao;

public interface IVerificarSessao
{
    Task<ResponseModel<UtilizadorModel>> VerificarLogin(UtilizadorDTO utilizadorDTO);
}
