namespace SisPDC.DTOs;

public class ConsultaDTO
{
    public int IdConsulta { get; set; }
    public string IdUtente { get; set; } = string.Empty;
    public string IdPessoaClinica { get; set; } = string.Empty;
    public DateTime DataConsulta { get; set; }
    public TimeSpan HoraConsulta { get; set; }
    public string? Descricao { get; set; }
    public string Estado { get; set; } = "Pendente";
    public string? Observacoes { get; set; }
    public string DataFormatada => DataConsulta.ToString("dd/MM/yyyy");
    public string HoraFormatada => HoraConsulta.ToString(@"hh\:mm");
}
