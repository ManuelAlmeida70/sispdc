using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;
using SisPDC.Services.CriptPassword;

namespace SisPDC.Services.Utilizador.VerificarSessao;

public class VerificarSessao : IVerificarSessao
{
    private readonly IUtilizadorRepository _utilizadorRepository;
    private readonly ICriptPassword _criptPassword;
    

    public VerificarSessao(IUtilizadorRepository utilizadorRepository, ICriptPassword criptPassword)
    {
        _utilizadorRepository = utilizadorRepository;
        _criptPassword = criptPassword;
        
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

            
            response.Message = "Sessao iniciada com sucesso";
            response.Data = utilizador;
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
