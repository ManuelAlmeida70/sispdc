using System.ComponentModel.DataAnnotations;

namespace SisPDC.DTOs;

public class UtenteDTO
{
   
    // ========================================
    // CREDENCIAIS DE ACESSO (Tabela Utilizador)
    // ========================================

    [Required(ErrorMessage = "O email de acesso é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    [Display(Name = "Email de Acesso")]
    public string? EmailAcesso { get; set; }

    [Required(ErrorMessage = "A palavra-passe é obrigatória")]
    [MinLength(6, ErrorMessage = "A palavra-passe deve ter no mínimo 6 caracteres")]
    [Display(Name = "Palavra-Passe")]
    public string? PalavraPasse { get; set; }

    [Required(ErrorMessage = "A confirmação da palavra-passe é obrigatória")]
    [Compare("PalavraPasse", ErrorMessage = "As palavras-passe não coincidem")]
    [Display(Name = "Confirmar Palavra-Passe")]
    public string? ConfirmarPalavraPasse { get; set; }

    [Required]
    public string TipoUtilizador { get; set; } = "Utente";

    // ========================================
    // DADOS PESSOAIS (Tabela Utente)
    // ========================================

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres")]
    [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres")]
    [Display(Name = "Nome Completo")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    // ========================================
    // CONTACTO
    // ========================================

    [MinLength(9, ErrorMessage = "O telefone não pode ter menos 9 caracteres")]
    [MaxLength(9, ErrorMessage = "O telefone não pode exceder 9 caracteres")]
    [RegularExpression(@"^[0-9+\s]+$", ErrorMessage = "O telefone deve conter apenas números, + e espaços")]
    [Display(Name = "Telefone")]
    public string Telefone { get; set; }

    // ========================================
    // ENDEREÇO
    // ========================================

    [MaxLength(150, ErrorMessage = "A morada não pode exceder 150 caracteres")]
    [Display(Name = "Morada")]
    public string Morada { get; set; } = string.Empty;

    [RegularExpression(@"^\d{4}-\d{3}$", ErrorMessage = "O código postal deve estar no formato 0000-000")]
    [MaxLength(20)]
    [Display(Name = "Código Postal")]
    public string CodigoPostal { get; set; } = string.Empty;

    [MaxLength(80, ErrorMessage = "A localidade não pode exceder 80 caracteres")]
    [Display(Name = "Localidade")]
    public string Localidade { get; set; } = string.Empty;

    // ========================================
    // INFORMAÇÕES ADMINISTRATIVAS
    // ========================================

    [Required(ErrorMessage = "O número é obrigatório")]
    [MaxLength(50, ErrorMessage = "O número de utente não pode exceder 50 caracteres")]
    [Display(Name = "Número de Utente")]
    public string? NumeroUtente { get; set; }

    [MaxLength(100, ErrorMessage = "A entidade financiadora não pode exceder 100 caracteres")]
    [Display(Name = "Entidade Financiadora")]
    public string EntidadeFinanciadora { get; set; } = string.Empty;
}
