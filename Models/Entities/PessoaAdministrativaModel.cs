using DocumentFormat.OpenXml.Office2010.Excel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisPDC.Models.Entities;

[Table("pessoaAdministrativas")]
public class PessoaAdministrativaModel
{
    [Key]
    [Column("idPessoaAdmin")]
    [StringLength(15)]
    public string IdPessoaAdmin { get; set; } = string.Empty;

    [Required]
    [Column("idUtilizador")]
    public int IdUtilizador { get; set; }

    [Required]
    [Column("nome")]
    [StringLength(100)]
    [MinLength(2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [Column("email")]
    [StringLength(100)]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Column("telefone")]
    [StringLength(20)]
    [RegularExpression(@"^[0-9+]*$", ErrorMessage = "O telefone deve conter apenas números e o símbolo +")]
    public string Telefone { get; set; } = string.Empty;

    [Column("cargo")]
    [StringLength(50)]
    public string Cargo { get; set; } = string.Empty;

    [Column("dataAdmissao")]
    [DataType(DataType.Date)]
    public DateTime? DataAdmissao { get; set; }

    // Endereço
    [Column("morada")]
    [StringLength(150)]
    public string Morada { get; set; } = string.Empty;

    [Column("codigoPostal")]
    [StringLength(20)]
    public string CodigoPostal { get; set; } = string.Empty;

    [Column("localidade")]
    [StringLength(80)]
    public string Localidade { get; set; } = string.Empty;

    [Column("ativo")]
    public bool Ativo { get; set; } = true;

    // Navegação
    [ForeignKey("IdUtilizador")]
    public virtual UtilizadorModel? Utilizador { get; set; }
}
