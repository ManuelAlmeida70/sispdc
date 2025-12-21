using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;
using SisPDC.Services.CriptPassword;
using SisPDC.Services.Medico.GerarNumeroMedico;
using SisPDC.Services.Utilizador.VerifyEmail;

namespace SisPDC.Services.Medico.Add;

public class AddMedico : IAddMedico
{
    private readonly IPessoaClinicaRepository _pessoaClinicaRepository;
    private readonly IUtilizadorRepository _utilizadorRepository;
    private readonly IVerifyEmail _verifyEmail;
    private readonly ICriptPassword _criptPassword;
    private readonly IGerarNumeroMedico _gerarNumeroMedico;
    public AddMedico(IPessoaClinicaRepository pessoaClinicaRepository, IVerifyEmail verifyEmail,
            ICriptPassword criptPassword,
            IUtilizadorRepository utilizadorRepository,
            IGerarNumeroMedico gerarNumeroMedico)
    {
        _pessoaClinicaRepository = pessoaClinicaRepository;
        _verifyEmail = verifyEmail;
        _criptPassword = criptPassword;
        _utilizadorRepository = utilizadorRepository;
        _gerarNumeroMedico = gerarNumeroMedico;
    }
    public async Task<ResponseModel<PessoaClinicaModel>> Execute(PessoaClinicoDTO pessoaClinicoDTO)
    {
        ResponseModel<PessoaClinicaModel> response = new ResponseModel<PessoaClinicaModel>();

        try
        {
            bool emailExist = await _verifyEmail.Execute(pessoaClinicoDTO.EmailAcesso!);

            if (emailExist)
            {
                response.Message = "O email informado ja existe";
                response.Status = false;
                return response;
            }

            _criptPassword.CreatePasswordHash(pessoaClinicoDTO.PalavraPasse!, out byte[] PasswordHash, out byte[] PasswordSalt);

            var utilizador = new UtilizadorModel()
            {
                DataCriacao = DateTime.Now,
                Ativo = true,
                Email = pessoaClinicoDTO.EmailAcesso!,
                UltimoAcesso = DateTime.Now,
                PalavraPasse = PasswordHash,
                PalavraPasseSalt = PasswordSalt,
                Nome = pessoaClinicoDTO.Nome,
                TipoUtilizador = "Clinico"
            };
            
            var resultUtilizador = await _utilizadorRepository.Add(utilizador);

            var numeroMedico = await _gerarNumeroMedico.GerarPessoaClinico();

            var medico = new PessoaClinicaModel()
            {
                IdPessoaClinica = numeroMedico,
                Ativo = 1,
                Email = pessoaClinicoDTO.EmailAcesso!,
                Cargo = pessoaClinicoDTO.Cargo,
                CodigoPostal = pessoaClinicoDTO.CodigoPostal,
                DataAdmissao = DateTime.Now,
                Localidade = pessoaClinicoDTO.Localidade,
                Telefone = pessoaClinicoDTO.Telefone,
                Nome = pessoaClinicoDTO.Nome,
                IdUtilizador = resultUtilizador.IdUtilizador,
                DataNascimento = pessoaClinicoDTO.DataNascimento,
                IdEspecialidade = pessoaClinicoDTO.IdEspecialidade,
                Morada = pessoaClinicoDTO.Morada,
                NumeroCedula = pessoaClinicoDTO.NumeroCedula!
            };

            var resultpessoa = await _pessoaClinicaRepository.Add(medico);

            response.Data = medico;
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
