
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Utilizador.VerifyEmail;

public class VerifyEmail : IVerifyEmail
{
    private readonly IUtilizadorRepository _utilizadorRepository;
    public VerifyEmail(IUtilizadorRepository utilizadorRepository)
    {
        _utilizadorRepository = utilizadorRepository;
    }
    public async Task<bool> Execute(string email)
    {
        var result = await _utilizadorRepository.EmailExist(email);

        return result;
    }
}
