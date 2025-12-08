namespace SisPDC.DTOs;

using System.ComponentModel.DataAnnotations;

public class UtilizadorDTO
{
    // Corresponde ao campo name="tipoUtilizador"
    [Required(ErrorMessage = "O Tipo de Utilizador é obrigatório.")]
    [Display(Name = "Tipo de Utilizador")]
    public string? TipoUtilizador { get; set; }

    // Corresponde ao campo name="email"
    [Required(ErrorMessage = "O Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email não é válido.")]
    [Display(Name = "Endereço de Email")]
    public string? Email { get; set; }

    // Corresponde ao campo name="password"
    [Required(ErrorMessage = "A Palavra-Passe é obrigatória.")]
    [DataType(DataType.Password)]
    [Display(Name = "Palavra-Passe")]
    public string? Password { get; set; }
}
