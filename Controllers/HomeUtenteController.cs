using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;
using SisPDC.Services.Consulta.Add;
using System.Threading.Tasks;

namespace SisPDC.Controllers;

[Authorize(Roles = "Utente")]
public class HomeUtenteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult MarcarConsultaUtente()
    {
        return View("~/Views/MarcarConsultaUtente/MarcarConsultaUtente.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> MarcarConsulta(ConsultaDTO consultaDTO, [FromServices] IAddConsulta useCase)
    {

        var consulta = await useCase.Execute(consultaDTO);

        if (consulta.Data is null)
        {
            TempData["ErrorMessage"] = consulta.Message;
        }
        else
        {
            TempData["SuccessMessage"] = consulta.Message;
        }
        return View("~/Views/MarcarConsultaUtente/MarcarConsultaUtente.cshtml");
    }
}
