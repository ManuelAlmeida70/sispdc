using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;
using SisPDC.Services.Utilizador.VerifyEmail;

namespace SisPDC.Services.Utente.Add;

public class AddUtente : IAddUtente
{
    private readonly IUtenteRepository _utenteRepository;
    private readonly IUtilizadorRepository _utilizadorRepository;
    private readonly IVerifyEmail _verifyEmail;

    public AddUtente(IUtilizadorRepository utilizadorRepository, IUtenteRepository utenteRepository, IVerifyEmail verifyEmail)
    {
        _utilizadorRepository = utilizadorRepository;
        _utenteRepository = utenteRepository;
        _verifyEmail = verifyEmail;
    }
    public async Task<UtenteModel> Execute(UtenteDTO utenteDTO)
    {
        try
        {
            var emailExist = await _verifyEmail.Execute(utenteDTO.EmailAcesso!);

            if (emailExist) 
            {
                return null!;
            }

            var utilizador = new UtilizadorModel()
            {
                Ativo = true,
                DataCriacao = DateTime.Now,
                Email = utenteDTO.EmailAcesso!,
                PalavraPasse = HashPasswrod(),
                PalavraPasseSalt = SaltPassword(),
                TipoUtilizador = "utente",
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
                Telefone = utenteDTO.Telefone,
                Utilizador = resultUtilizador
            };

            var resultUtente = await _utenteRepository.Add(utente);

            if (resultUtente == null)
                return null!;
            
            return resultUtente;

        }
        catch (Exception ex) 
        { 
            Console.WriteLine(ex.ToString());
        }
        throw new NotImplementedException();
    }

    private string HashPasswrod()
    {
        string password  ="Senha";

        return password;
    }

    private string SaltPassword()
    {
        string salt = "Salt";

        return salt;
    }
}
