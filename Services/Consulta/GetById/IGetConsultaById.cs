using SisPDC.Models.Entities;

namespace SisPDC.Services.Consulta.GetById;

public interface IGetConsultaById
{
    Task<ResponseModel<ConsultaModel>> Execute(int id);
}
