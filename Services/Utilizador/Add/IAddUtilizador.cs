using SisPDC.Models.Entities;

namespace SisPDC.Services.Utilizador.Add;

public interface IAddUtilizador
{
    Task<UtilizadorModel> Execute(UtilizadorModel utilizadorModel);
}
