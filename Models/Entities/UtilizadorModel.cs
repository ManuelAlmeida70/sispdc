namespace SisPDC.Models.Entities;

public class UtilizadorModel
{
    public int IdUtilizador { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PalavraPasse { get; set; } = string.Empty;
    public string PalavraPasseSalt { get; set; } = string.Empty;
    public string TipoUtilizador { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public DateTime? UltimoAcesso { get; set; }
    public bool Ativo { get; set; } = true;
}
