using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SisPDC.Models.Entities;
using System.Text.Json.Serialization;

namespace SisPDC.Services.Utilizador.IniciarSessao;

public class IniciarSessao : IIniciarSessao
{
    private readonly IHttpContextAccessor _contextAccessor;

    public IniciarSessao(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    public void CriarSessao(UtilizadorModel utilizadorModel)
    {
        var utilizadorJSON = JsonConvert.SerializeObject(utilizadorModel);

        _contextAccessor.HttpContext.Session.SetString("SessaoUtilizador", utilizadorJSON);
    }

    public UtilizadorModel PesquisarSessao()
    {
        var sessaoUtilizador = _contextAccessor.HttpContext.Session.GetString("SessaoUtilizador");

        if (string.IsNullOrEmpty(sessaoUtilizador))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<UtilizadorModel>(sessaoUtilizador);
    }

    public void RemoverSessao()
    {
        _contextAccessor.HttpContext.Session.Remove("SessaoUtilizador");
    }
}
