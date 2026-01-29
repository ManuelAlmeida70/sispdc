using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisPDC.Models.Entities;

[Table("Consultas")]
public class ConsultaModel
{
    
    [Key]
    [Column("idConsulta")]
    public int IdConsulta { get; set; }

    [Required]
    [Column("idUtente")]
    [StringLength(20)]
    public string IdUtente { get; set; } = string.Empty;

    [Column("idPessoaClinica")]
    [StringLength(20)]
    public string? IdPessoaClinica { get; set; }

    [Required]
    [Column("dataConsulta")]
    [DataType(DataType.Date)]
    public DateTime DataConsulta { get; set; }

    [Required]
    [Column("horaConsulta")]
    [DataType(DataType.Time)]
    public TimeSpan HoraConsulta { get; set; }

    [Column("descricao")]
    [StringLength(200)]
    public string? Descricao { get; set; }

    [Column("observacoes")]
    [StringLength(500)]
    public string? Observacoes { get; set; }

    [Required]
    [Column("estado")]
    [StringLength(20)]
    public string Estado { get; set; } = "Pendente";

    [Column("dataCriacao")]
    public DateTime DataCriacao { get; set; }

    [Column("dataUltimaAtualizacao")]
    public DateTime? DataUltimaAtualizacao { get; set; }

    // Propriedades de Navegação
    [ForeignKey("IdUtente")]
    public virtual UtenteModel? Utente { get; set; }

    [ForeignKey("IdPessoaClinica")]
    public virtual PessoaClinicaModel? PessoaClinica { get; set; }

    // Propriedade calculada para facilitar exibição
    [NotMapped]
    public DateTime DataHoraConsulta => DataConsulta.Add(HoraConsulta);

    [NotMapped]
    public string EstadoFormatado => Estado switch
    {
        "Pendente" => "Pendente",
        "Marcado" => "Confirmada",
        "Realizada" => "Realizada",
        "Cancelada" => "Cancelada",
        _ => Estado
    };
 

}
