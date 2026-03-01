using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;
using SisPDC.Services.Consulta.Add;
using SisPDC.Services.Exames.Add;

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

    public IActionResult MarcarExameUtente()
    {
        return View("~/Views/MarcarExameUtente/MarcarExameUtente.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> MarcarExameUtente(CriarExameDTO criarExameDTO, [FromServices] IAddExame useCase)
    {
        var response = await useCase.Execute(criarExameDTO);

        if (response.Data is null)
        {
            TempData["ErrorMessage"] = response.Message;
        }
        else
        {
            TempData["SuccessMessage"] = response.Message;
        }

        return View("~/Views/MarcarExameUtente/MarcarExameUtente.cshtml");
    }
}
