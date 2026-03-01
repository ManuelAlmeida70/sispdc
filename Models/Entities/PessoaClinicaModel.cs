using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisPDC.Models.Entities;

public class PessoaClinicaModel
{
    [Key]
    [Required]
    [RegularExpression(@"^UT\d{4}\d{6}$", ErrorMessage = "Formato invalidado do pessoa administrativa codigo")]
    public string IdPessoaClinica { get; set; } = string.Empty;
    public int IdUtilizador { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string? Cargo { get; set; }          // nullable
    public DateTime? DataAdmissao { get; set; } = DateTime.Now;
    public DateTime DataNascimento { get; set; }
    public string? Morada { get; set; }         // nullable
    public string? CodigoPostal { get; set; }   // nullable
    public string? Localidade { get; set; }     // nullable
    public short Ativo { get; set; } = 1;
    public string? NumeroCedula { get; set; }   // nullable  <-- este é o que está quebrando agora
    public int IdEspecialidade { get; set; }


    [ForeignKey("IdEspecialidade")]
    public virtual EspecialidadeModel? Especialidade { get; set; }
}