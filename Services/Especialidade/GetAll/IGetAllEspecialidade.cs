using SisPDC.Models.Entities;

namespace SisPDC.Services.Especialidade.GetAll;

public interface IGetAllEspecialidade
{
    Task<List<EspecialidadeModel>> Execute(); 
}
