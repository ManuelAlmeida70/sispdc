using System.Data;

namespace SisPDC.Services.Especialidade.GerarRelatorioExcel;

public interface IGerarRelatorioExcel
{
    Task <DataTable> GerarRelatorio();
}
