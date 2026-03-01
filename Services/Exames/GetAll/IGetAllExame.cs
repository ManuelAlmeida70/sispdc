using SisPDC.DTOs;

namespace SisPDC.Services.Exames.GetAll;

public interface IGetAllExame
{
    Task<IEnumerable<ExameListagemDTO>> Execute();

}
