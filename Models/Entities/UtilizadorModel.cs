using System.ComponentModel.DataAnnotations;

namespace SisPDC.Models.Entities;

public class UtilizadorModel
{
    [Key]
    public int IdUtilizador { get; set; }
    public string Email { get; set; } = string.Empty;
    public required byte[] PalavraPasse { get; set; }
    public required byte[] PalavraPasseSalt { get; set; }
    public string TipoUtilizador { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public DateTime? UltimoAcesso { get; set; }
    public bool Ativo { get; set; } = true;
}
