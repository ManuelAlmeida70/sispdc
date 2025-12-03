using SisPDC.Models.Entities;

namespace SisPDC.Services.Especialidade.Add;

public interface IAddEspecialidade
{
    Task  Execute(EspecialidadeModel especialidadeModel);
}
