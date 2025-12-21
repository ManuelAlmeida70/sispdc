namespace SisPDC.DTOs;

public class PessoaClinicoEliminarDTO
{
    public string Nome { get; set; } = string.Empty;
    public string IdClinico { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public string IdEspecialidade { get; set; } = string.Empty;
    public int IdUtilizador { get; set; }
    public string Email {  get; set; } = string.Empty;
}
