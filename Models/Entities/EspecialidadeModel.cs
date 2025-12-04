using System.ComponentModel.DataAnnotations;

namespace SisPDC.Models.Entities;

public class EspecialidadeModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Digite a descrição da especialidade")]
    public string Descricao {  get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
}
