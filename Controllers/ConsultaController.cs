using Microsoft.AspNetCore.Mvc;
using SisPDC.Services.Consulta.GetAll;
using System.Threading.Tasks;

namespace SisPDC.Controllers;
public class ConsultaController : Controller
{
    public async Task<IActionResult> Index([FromServices] IGetAllConsulta useCase)
    {
        var consultas = await useCase.Execute();

        return View(consultas);
    }
}
