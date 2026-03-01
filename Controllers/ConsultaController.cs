using Microsoft.AspNetCore.Mvc;
using SisPDC.Services.Consulta.AtribuirMedico;
using SisPDC.Services.Consulta.GetAll;
using SisPDC.Services.Consulta.GetById;
using SisPDC.Services.Medico.GetAll;
using System.Threading.Tasks;

namespace SisPDC.Controllers;
public class ConsultaController : Controller
{
    public async Task<IActionResult> Index([FromServices] IGetAllConsulta useCase)
    {
        var consultas = await useCase.Execute();

        return View(consultas);
    }

    [HttpGet]
    public async Task<IActionResult> AtribuirConsultaPessoaClinica(
    [FromServices] IGetConsultaById consultaUseCase,
    [FromServices] IGetAllMedicos medicoUseCase,
    int id)
    {
        var consulta = await consultaUseCase.Execute(id);
        if (consulta is null || !consulta.Status)
        {
            TempData["ErrorMessage"] = consulta?.Message ?? "Consulta não encontrada.";
            return RedirectToAction("Index");
        }

        var medicos = await medicoUseCase.Execute();
        ViewBag.Medicos = medicos;

        return View(consulta.Data);
    }

    [HttpPost]
    public async Task<IActionResult> AtribuirConsultaPessoaClinica(
    [FromServices] IAtribuirConsultaMedico useCase,
    [FromServices] IGetAllMedicos medicoUseCase,
    int idConsulta,
    string idPessoaClinica)
    {
        var result = await useCase.Execute(idConsulta, idPessoaClinica);
        if (!result.Status)
        {
            TempData["ErrorMessage"] = result.Message;

            var medicos = await medicoUseCase.Execute();
            ViewBag.Medicos = medicos;

            return View();
        }

        TempData["SuccessMessage"] = result.Message;
        return RedirectToAction("Index");
    }
}
