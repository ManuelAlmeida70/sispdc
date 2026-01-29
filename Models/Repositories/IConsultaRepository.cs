using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IConsultaRepository
{
    Task Add(ConsultaModel consulta);
    Task<List<ConsultaModel>> GetAll();
    Task<ConsultaModel> GetByIdUtente(string? id);
    Task<ConsultaModel> GetByIdPessoaAdministrativa(string? id);
}
