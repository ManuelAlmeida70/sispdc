using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Services.Utente.Add;

public interface IAddUtente
{
    Task<UtenteModel> Execute(UtenteDTO UtenteDTO);
}
