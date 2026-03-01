using System;

namespace SisPDC.DTOs
{
    public class ExameListagemDTO
    {
        public int IdExame { get; set; }
        public string TipoExame { get; set; }
        public string Descricao { get; set; }
        public DateTime DataRequisicao { get; set; }
        public DateTime? DataPrevista { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public string Estado { get; set; }
        public string NomeMedico { get; set; }
        public string EspecialidadeMedico { get; set; }
        public bool TemResultados { get; set; }
        public bool TemArquivo { get; set; }

        // Propriedade calculada para exibir status com cor
        public string EstadoClass
        {
            get
            {
                return Estado switch
                {
                    "Requisitado" => "badge bg-warning text-dark",
                    "Agendado" => "badge bg-info",
                    "Realizado" => "badge bg-success",
                    "Cancelado" => "badge bg-danger",
                    _ => "badge bg-secondary"
                };
            }
        }

        // Propriedade calculada para ícone do estado
        public string EstadoIcone
        {
            get
            {
                return Estado switch
                {
                    "Requisitado" => "bi-hourglass-split",
                    "Agendado" => "bi-calendar-check",
                    "Realizado" => "bi-check-circle",
                    "Cancelado" => "bi-x-circle",
                    _ => "bi-question-circle"
                };
            }
        }

        // Data formatada para exibição
        public string DataFormatada
        {
            get
            {
                if (DataRealizacao.HasValue)
                    return DataRealizacao.Value.ToString("dd/MM/yyyy");
                if (DataPrevista.HasValue)
                    return DataPrevista.Value.ToString("dd/MM/yyyy");
                return DataRequisicao.ToString("dd/MM/yyyy");
            }
        }
    }
}