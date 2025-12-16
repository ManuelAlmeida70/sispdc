using System.ComponentModel.DataAnnotations;

namespace SisPDC.DTOs;

public class PessoaClinicoDTO : IValidatableObject
{
    // ========================================
    // CREDENCIAIS DE ACESSO (Tabela Utilizador)
    // ========================================

    [Required(ErrorMessage = "O email de acesso é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    [Display(Name = "Email de Acesso")]
    public string? EmailAcesso { get; set; }

    [Required(ErrorMessage = "O especialidade é obrigatório")]
    public int IdEspecialidade { get; set; }

    [Display(Name = "Palavra-Passe")]
    public string? PalavraPasse { get; set; } = "medico@sispdc.ao";

    [Required]
    public string TipoUtilizador { get; set; } = "Clinico";

    // ========================================
    // (Tabela PessoaAdministrativa)
    // ========================================
    [Required(ErrorMessage = "O cargo é obrigatório")]
    public string Cargo {  get; set; } = string.Empty;

    [Required(ErrorMessage = "O codigo postal é obrigatório")]
    public string CodigoPostal {  get; set; } = string.Empty;

    [Required(ErrorMessage = "A localidade é obrigatório")]
    public string Localidade {  get; set; } = string.Empty;

    [Required(ErrorMessage = "A telefone é obrigatório")]
    public string Telefone {  get; set; } = string.Empty;

    [Required(ErrorMessage = "A nome é obrigatório")]
    public string Nome {  get; set; } = string.Empty;

    [Required(ErrorMessage = "A morada é obrigatório")]
    public string Morada {  get; set; } = string.Empty;

    public string? NumeroCedula { get; set; } = string.Empty;
    [Required(ErrorMessage = "indique se profissional pode fazer login")]
    public bool Ativo { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var cargosComCedula = new[] { "Médico", "Enfermeiro" };

        if (cargosComCedula.Contains(Cargo, StringComparer.OrdinalIgnoreCase))
        {
            if (string.IsNullOrWhiteSpace(NumeroCedula))
            {
                yield return new ValidationResult(
                    $"O número de cédula profissional é obrigatório para {Cargo}",
                    new[] { nameof(NumeroCedula) }
                );
            }
        }
    }
}
