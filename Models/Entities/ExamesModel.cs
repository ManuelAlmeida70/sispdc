using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisPDC.Models.Entities;

public class ExamesModel
{
    [Key]
    [Column("idExame")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdExame { get; set; }

    [Required]
    [Column("idUtente")]
    [StringLength(15)]
    public string IdUtente { get; set; }

    [Column("idPessoaClinica")]
    [StringLength(15)]
    public string? IdPessoaClinica { get; set; }

    [Column("idConsulta")]
    public int? IdConsulta { get; set; }

    [Required]
    [Column("tipoExame")]
    [StringLength(100)]
    public string? TipoExame { get; set; }

    [Column("descricao")]
    [StringLength(200)]
    public string? Descricao { get; set; }

    [Required]
    [Column("dataRequisicao")]
    [DataType(DataType.Date)]
    public DateTime DataRequisicao { get; set; }

    [Column("dataPrevista")]
    [DataType(DataType.Date)]
    public DateTime? DataPrevista { get; set; }

    [Column("dataRealizacao")]
    [DataType(DataType.Date)]
    public DateTime? DataRealizacao { get; set; }

    [Column("resultados", TypeName = "TEXT")]
    public string? Resultados { get; set; }

    [Column("observacoes")]
    [StringLength(500)]
    public string? Observacoes { get; set; }

    [Required]
    [Column("estado")]
    [StringLength(20)]
    public string? Estado { get; set; }

    [Column("caminhoArquivo")]
    [StringLength(255)]
    public string? CaminhoArquivo { get; set; }

    [Required]
    [Column("dataCriacao")]
    public DateTime DataCriacao { get; set; }

    [Column("dataUltimaAtualizacao")]
    public DateTime? DataUltimaAtualizacao { get; set; }

    [Required]
    [Column("ativo")]
    public short Ativo { get; set; } = 1;

    // Navegação - Relacionamentos
    [ForeignKey("IdUtente")]
    public virtual UtenteModel Utente { get; set; }

    [ForeignKey("IdPessoaClinica")]
    public virtual PessoaClinicaModel PessoaClinica { get; set; }

    [ForeignKey("IdConsulta")]
    public virtual ConsultaModel Consulta { get; set; }

    // Construtor
    public ExamesModel()
    {
        DataRequisicao = DateTime.Now;
        DataCriacao = DateTime.Now;
        Estado = "Requisitado";
        Ativo = 1;
    }
}
