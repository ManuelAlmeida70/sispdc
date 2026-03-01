using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IConsultaRepository
{
    Task Add(ConsultaModel consulta);
    Task<List<ConsultaModel>> GetAll();
    Task<List<ConsultaModel>> GetByIdUtenteAll(string? id);
    Task<ConsultaModel> GetByIdPessoaClinica(string? id);
    Task<ConsultaModel> GetById(string? id);
    Task<bool> AtribuirMedico(int idConsulta, string idPessoaClinica);
}
