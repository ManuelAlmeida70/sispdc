using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Models.Repositories;

public interface IExameRepository
{
    Task Add(ExamesModel exame);

    Task<IEnumerable<ExamesModel>> GetAll();
    Task<IEnumerable<ExamesModel>> GetAllByIdUtente(string idUtente);
    Task<IEnumerable<ExamesModel>> GetAllByIdMedico(string idMedico);

}
