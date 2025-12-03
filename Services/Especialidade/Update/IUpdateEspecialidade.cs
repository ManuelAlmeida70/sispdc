using SisPDC.Models.Entities;

namespace SisPDC.Services.Especialidade.Update;

public interface IUpdateEspecialidade
{
    Task Execute(EspecialidadeModel especialidadeModel);
}
