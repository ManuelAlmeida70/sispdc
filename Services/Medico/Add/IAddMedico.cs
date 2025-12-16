using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Medico.Add;

public interface IAddMedico
{
    Task<ResponseModel<PessoaClinicaModel>> Execute(PessoaClinicoDTO pessoadaClinicoDTO);
}
