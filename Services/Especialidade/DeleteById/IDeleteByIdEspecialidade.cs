using SisPDC.Models.Entities;

namespace SisPDC.Services.Especialidade.DeleteById;

public interface IDeleteByIdEspecialidade
{
    Task Execute(EspecialidadeModel especialidadeModel);
}
