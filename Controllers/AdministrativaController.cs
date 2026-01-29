using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;
using SisPDC.Services.Administrativa.Add;
using SisPDC.Services.Administrativa.GetAll;
using System.Threading.Tasks;

namespace SisPDC.Controllers;

[Authorize(Roles = "Administrativo")]
public class AdministrativaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Listar([FromServices] IGetAllAdministrativa useCase)
    {
        var administrativas = await useCase.Execute();
        return View(administrativas);
    }

    [HttpGet]
    public IActionResult Criar()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Criar(PessoaAdministrativasDTO administrativaDTO, [FromServices] IAddAdministrativa useCase)
    {
        if (ModelState.IsValid)
        {
            var result = await useCase.Execute(administrativaDTO);

            if (result != null)
            {
                TempData["SuccessMessage"] = result.Message;

                return RedirectToAction("Listar", "Administrativa");
            }
            else
            {
                TempData["SuccessMessage"] = null;
                TempData["ErrorMessage"] = result!.Message.ToString();

                return RedirectToAction("Listar", "Administrativa");
            }
        }

        return View();
    }
}
