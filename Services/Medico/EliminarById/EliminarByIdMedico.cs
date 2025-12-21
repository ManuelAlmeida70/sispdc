using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Medico.EliminarById;

public class EliminarByIdMedico : IEliminarByIdMedico
{
    private readonly IPessoaClinicaRepository _pessoaClinicaRepository;
    private  readonly IUtilizadorRepository _utilizadorRepository;

    public EliminarByIdMedico(IPessoaClinicaRepository pessoaClinicaRepository, IUtilizadorRepository utilizadorRepository)
    {
        _pessoaClinicaRepository = pessoaClinicaRepository;
        _utilizadorRepository = utilizadorRepository;
    }
    public async Task<PessoaClinicoEliminarDTO> Execute(PessoaClinicoEliminarDTO clinicoEliminarDTO)
    {
        try
        {
            // Busca o médico
            var medico = await _pessoaClinicaRepository.GetByIdMedicos(clinicoEliminarDTO.IdClinico);
            if (medico == null)
                throw new Exception("Médico não encontrado");

            // Elimina o médico
            await _pessoaClinicaRepository.EliminarByIdMedico(medico);

            // Elimina o utilizador por ID
            var utilizadorEliminado = await _utilizadorRepository.EliminarById(clinicoEliminarDTO.IdUtilizador);

            if (!utilizadorEliminado)
                throw new Exception("Utilizador não encontrado");

            return clinicoEliminarDTO;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao eliminar: {e.Message}");
            throw;
        }
    }
}
