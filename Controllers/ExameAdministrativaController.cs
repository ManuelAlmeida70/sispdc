using Microsoft.AspNetCore.Mvc;
using SisPDC.Services.Exames.GetAll;

namespace SisPDC.Controllers;
public class ExameAdministrativaController : Controller
{
    public async Task<IActionResult>Index([FromServices] IGetAllExame useCase)
    {
        var exames = await useCase.Execute();
        Console.WriteLine($"Total exames: {exames.Count()}");
        return View(exames);
    }
}
