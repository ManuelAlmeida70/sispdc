using SisPDC.Models.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace SisPDC.Services.Especialidade.GerarRelatorioExcel;

public class GerarRelatorioExcel : IGerarRelatorioExcel
{

    private readonly IEspecialidadeRepository _especialidadeRepository;

    public GerarRelatorioExcel(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }
    public async Task<DataTable> GerarRelatorio()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Codigo", typeof(string));
        dt.Columns.Add("Descricao", typeof(string));
        dt.Columns.Add("Data de cadastramento", typeof(DateTime));

        var especialidades = await _especialidadeRepository.GetAll();

        if (especialidades.Count != 0)
        {
            especialidades.ForEach(especialidade =>
            {
                dt.Rows.Add($"00{especialidade.Id}", especialidade.Descricao, especialidade.DateTime);
            });
        }

        return dt;
    }
}
