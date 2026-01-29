using System.ComponentModel.DataAnnotations;

namespace SisPDC.DTOs;

public class PessoaAdministrativasDTO
{
   
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100)]
    [MinLength(2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres")]
    //[RegularExpression(@"^[a-z]*$", ErrorMessage = "O nome deve conter apenas caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email de acesso é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    [Display(Name = "Email de Acesso")]
    public string? Email { get; set; }

    [StringLength(20)]
    [RegularExpression(@"^[0-9+]*$", ErrorMessage = "O telefone deve conter apenas números e o símbolo +")]
    public string Telefone { get; set; } = string.Empty;

    [StringLength(50)]
    [Required(ErrorMessage = "O cargo é obrigatório")]
    public string Cargo { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime? DataAdmissao { get; set; } = DateTime.Now;


    

    [Required]
    public string TipoUtilizador { get; set; } = "Administrativo";

    // Endereço
    [StringLength(150)]
    [Required(ErrorMessage = "A morada é obrigatório")]
    public string Morada { get; set; } = string.Empty;

    [StringLength(20)]
    public string CodigoPostal { get; set; } = string.Empty;

    [StringLength(80)]
    public string Localidade { get; set; } = string.Empty;
    public string PalavraPasse { get; set; } = "administrativo@sispdc";

    public bool Ativo { get; set; } = true;

}
