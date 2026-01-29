using SisPDC.Data.Repositories;
using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;
using SisPDC.Services.Administrativa.GerarNumeroAdministrativo;
using SisPDC.Services.CriptPassword;
using SisPDC.Services.Utilizador.VerifyEmail;

namespace SisPDC.Services.Administrativa.Add;

public class AddAdministrativa : IAddAdministrativa
{
    private readonly IPessoaAdministrativaRepository _administrativaRepository;
    private readonly IUtilizadorRepository _utilizadorRepository;
    private readonly IVerifyEmail _verifyEmail;
    private readonly ICriptPassword _criptPassword;
    private readonly IGerarNumeroAdministrativo _gerarNumeroAdministrativo;

    public AddAdministrativa(IPessoaAdministrativaRepository pessoaAdministrativaRepository,
            IVerifyEmail verifyEmail, ICriptPassword criptPassword,
            IUtilizadorRepository utilizadorRepository,
            IGerarNumeroAdministrativo gerarNumeroAdministrativo)
    {
        _administrativaRepository = pessoaAdministrativaRepository;
        _utilizadorRepository = utilizadorRepository;
        _verifyEmail = verifyEmail;
        _criptPassword = criptPassword;
        _gerarNumeroAdministrativo = gerarNumeroAdministrativo;
    }
    public async Task<ResponseModel<PessoaAdministrativaModel>> Execute(PessoaAdministrativasDTO administrativasDTO)
    {

        ResponseModel<PessoaAdministrativaModel> response = new ResponseModel<PessoaAdministrativaModel>();

        try
        {
            bool emailExist = await _verifyEmail.Execute(administrativasDTO.Email!);
            if (emailExist == true)
            {
                response.Status = false;
                response.Message = "Email ja cadastrado!";
                return response;
            }

            _criptPassword.CreatePasswordHash(administrativasDTO.PalavraPasse!, out byte[] PasswordHash, out byte[] PasswordSalt);
            var utilizador = new UtilizadorModel()
            {
                Ativo = administrativasDTO.Ativo,
                Email = administrativasDTO.Email!,
                Nome = administrativasDTO.Nome,
                TipoUtilizador = administrativasDTO.TipoUtilizador,
                PalavraPasse = PasswordHash,
                PalavraPasseSalt = PasswordSalt,
                DataCriacao = DateTime.Now
            };

            var resultUtilizador = await _utilizadorRepository.Add(utilizador);


            var pessoaAdministrativa = new PessoaAdministrativaModel()
            {
                IdPessoaAdmin = await _gerarNumeroAdministrativo.GerarPessoaAdministrativo(),
                Cargo = administrativasDTO.Cargo,
                CodigoPostal = administrativasDTO.CodigoPostal,
                Email = administrativasDTO.Email!,
                Localidade = administrativasDTO.Localidade,
                Nome = administrativasDTO.Nome!,
                IdUtilizador = resultUtilizador.IdUtilizador,
                Telefone = administrativasDTO.Telefone,
                Morada = administrativasDTO.Morada
            };

            await  _administrativaRepository.Add(pessoaAdministrativa);



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
