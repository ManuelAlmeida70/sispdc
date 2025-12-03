using SisPDC.Models.Entities;

namespace SisPDC.Services.Especialidade.GetById;

public interface IGetByIdEspecialidade
{
    Task<EspecialidadeModel> Execute(int? id);
}
