using System.ComponentModel.DataAnnotations;

namespace SisPDC.Models.Entities;

public class PessoaClinicaModel
{
    [Key]
    [Required]
    [RegularExpression(@"^UT\d{4}\d{6}$", ErrorMessage = "Formato invalidado do pessoa administrativa codigo")]
    public string IdPessoaClinica { get; set; } = string.Empty;

    public int IdUtilizadir { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cargo { get; set; }= string.Empty;
    public DateTime DataAdmissao { get; set; } = DateTime.Now;
    public DateTime DataNascimento { get; set; }
    public string Morada { get; set; } = string.Empty;
    public string CodigoPostal { get; set; } = string.Empty;
    public string Localidade { get; set; } = string.Empty;
    public short Ativo { get; set; } = 1;
}
