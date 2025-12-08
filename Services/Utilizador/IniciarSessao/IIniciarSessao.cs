using SisPDC.Models.Entities;

namespace SisPDC.Services.Utilizador.IniciarSessao;

public interface IIniciarSessao
{
    UtilizadorModel PesquisarSessao();
    void CriarSessao(UtilizadorModel utilizadorModel);
    void RemoverSessao();
}
