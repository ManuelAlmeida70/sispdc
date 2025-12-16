using System.ComponentModel.DataAnnotations;

namespace SisPDC.Models.Entities;

public class UtenteModel
{
    [Key]
    [Required]
    [RegularExpression(@"^UT\d{4}\d{6}$", ErrorMessage = "Formato invalidado")]
    public string IdUtente { get; set; }
    public int IdUtilizador { get; set; }

    // Dados Pessoais
    public DateTime DataNascimento { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    // Endereço
    public string? Morada { get; set; }
    public string? CodigoPostal { get; set; }
    public string? Localidade { get; set; }

    // Informações Administrativas
    public string? EntidadeFinanciadora { get; set; }
    public string? NumeroUtente { get; set; }
    public bool Ativo { get; set; } = true;
}
