using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;
using SisPDC.Services.CriptPassword;
using SisPDC.Services.Utilizador.IniciarSessao;

namespace SisPDC.Services.Utilizador.VerificarSessao;

public class VerificarSessao : IVerificarSessao
{
    private readonly IUtilizadorRepository _utilizadorRepository;
    private readonly ICriptPassword _criptPassword;
    private readonly IIniciarSessao _iniciarSessao;

    public VerificarSessao(IUtilizadorRepository utilizadorRepository, ICriptPassword criptPassword, IIniciarSessao iniciarSessao)
    {
        _utilizadorRepository = utilizadorRepository;
        _criptPassword = criptPassword;
        _iniciarSessao = iniciarSessao;
    }
    public async Task<ResponseModel<UtilizadorModel>> VerificarLogin(UtilizadorDTO utilizadorDTO)
    {
        ResponseModel<UtilizadorModel> response = new ResponseModel<UtilizadorModel>();
        try
        {
            var utilizador = await _utilizadorRepository.GetUitlizadorByEmail(utilizadorDTO.Email);

            if (utilizador == null)
            {
                response.Message = "Credencias invalidos";
                response.Status = false;
                return response;
            }

            if (!_criptPassword.VerifiPassword(utilizadorDTO.Password!, utilizador.PalavraPasse, utilizador.PalavraPasseSalt))
            {
                response.Message = "Credencias invalidos";
                response.Data = utilizador;
                response.Status = false;
                return response;
            }

            //Criar sessao
            _iniciarSessao.CriarSessao(utilizador);
            response.Message = "Sessao iniciada com sucesso";
            return response;

        }
        catch (Exception ex) 
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

}
