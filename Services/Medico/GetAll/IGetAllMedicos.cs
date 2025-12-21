using SisPDC.Models.Entities;

namespace SisPDC.Services.Medico.GetAll;

public interface IGetAllMedicos
{
    Task<List<PessoaClinicaModel>> Execute();
}
