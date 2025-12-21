using SisPDC.Models.Entities;

namespace SisPDC.Services.Medico.GetById;

public interface IGetByIdMedico
{
    Task<PessoaClinicaModel> Execute(string? id);
}
