using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Medico.EliminarById;

public interface IEliminarByIdMedico
{
    Task<PessoaClinicoEliminarDTO> Execute(PessoaClinicoEliminarDTO clinicoEliminarDTO);
}
