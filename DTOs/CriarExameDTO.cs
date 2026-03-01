using System;
using System.ComponentModel.DataAnnotations;

namespace SisPDC.DTOs
{
    public class CriarExameDTO
    {
        [Required(ErrorMessage = "O utente é obrigatório")]
        public string IdUtente { get; set; }

        public string IdPessoaClinica { get; set; }

        public int? IdConsulta { get; set; }

        [Required(ErrorMessage = "O tipo de exame é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O tipo de exame deve ter entre 3 e 100 caracteres")]
        [Display(Name = "Tipo de Exame")]
        public string TipoExame { get; set; }

        [StringLength(200, ErrorMessage = "A descrição não pode exceder 200 caracteres")]
        [Display(Name = "Especificação")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data prevista é obrigatória")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Prevista")]
        [FutureDate(ErrorMessage = "A data prevista deve ser futura")]
        public DateTime DataPrevista { get; set; }

        [StringLength(500, ErrorMessage = "As observações não podem exceder 500 caracteres")]
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        // Construtor
        public CriarExameDTO()
        {
            DataPrevista = DateTime.Now.AddDays(1);
        }
    }

    // Validação personalizada para data futura
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.Date >= DateTime.Now.Date;
            }
            return true;
        }
    }
}