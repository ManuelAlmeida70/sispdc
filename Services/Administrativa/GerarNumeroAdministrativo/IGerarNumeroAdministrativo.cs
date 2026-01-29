namespace SisPDC.Services.Administrativa.GerarNumeroAdministrativo;

public interface IGerarNumeroAdministrativo
{
    Task<string> GerarPessoaAdministrativo();
}
