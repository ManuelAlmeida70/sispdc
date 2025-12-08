using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;
using SisPDC.Services.CriptPassword;
using SisPDC.Services.Utilizador.VerifyEmail;

namespace SisPDC.Services.Utente.Add;

public class AddUtente : IAddUtente
{
    private readonly IUtenteRepository _utenteRepository;
    private readonly IUtilizadorRepository _utilizadorRepository;
    private readonly IVerifyEmail _verifyEmail;
    private readonly ICriptPassword _criptPassword;

    public AddUtente(IUtilizadorRepository utilizadorRepository, IUtenteRepository utenteRepository,
        IVerifyEmail verifyEmail, ICriptPassword criptPassword)
    {
        _utilizadorRepository = utilizadorRepository;
        _utenteRepository = utenteRepository;
        _verifyEmail = verifyEmail;
        _criptPassword = criptPassword;
    }
    public async Task<ResponseModel<UtenteModel>> Execute(UtenteDTO utenteDTO)
    {
        ResponseModel<UtenteModel> response = new ResponseModel<UtenteModel>();

        try
        {
            bool emailExist = await _verifyEmail.Execute(utenteDTO.EmailAcesso!);

            if (emailExist == true) 
            {
                response.Status = false;
                response.Message = "Email ja cadastrado!";
                return response;
            }

            utenteDTO.ConfirmarPalavraPasse = null;
            _criptPassword.CreatePasswordHash(utenteDTO.PalavraPasse!, out byte[] PasswordHash, out byte[] PasswordSalt);

            var utilizador = new UtilizadorModel()
            {
                Ativo = true,
                DataCriacao = DateTime.Now,
                Email = utenteDTO.EmailAcesso!,
                PalavraPasse = PasswordHash,
                PalavraPasseSalt = PasswordSalt,
                TipoUtilizador = "Utente",
                UltimoAcesso = DateTime.Now,
            };

            var resultUtilizador = await _utilizadorRepository.Add(utilizador);


            var utente = new UtenteModel()
            {
                Ativo = true,
                CodigoPostal = utenteDTO.CodigoPostal,
                DataNascimento = utenteDTO.DataNascimento,
                Email = utenteDTO.EmailAcesso!,
                EntidadeFinanciadora = utenteDTO.EntidadeFinanciadora,
                IdUtilizador = utilizador.IdUtilizador,
                Localidade = utenteDTO.Localidade,
                Morada = utenteDTO.Morada,
                Nome = utenteDTO.Nome,
                NumeroUtente = utenteDTO.NumeroUtente,
                Telefone = utenteDTO.Telefone
            };

            var resultUtente = await _utenteRepository.Add(utente);

            if (resultUtente == null)
                return null!;



            response.Message = "Conta cadastrada com sucesso!";
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
