using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Services.Utente.Add;
using System.Threading.Tasks;

namespace SisPDC.Controllers;
public class LoginController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CriarContaUtente()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarContaUtente(UtenteDTO utenteDTO, [FromServices] IAddUtente useCase)
    {
        if (ModelState.IsValid)
        {
            var utente = await useCase.Execute(utenteDTO);

            if (utente != null)
            {
                return View("Login");
            }
            TempData["ErrorMessage"] = "Erro ao cadastrar conta, o email ja existe!";
        }
        
        return View(utenteDTO);
    }

    public IActionResult IniciarSessao(UtilizadorDTO utilizadorDTO)
    {
        if (!ModelState.IsValid)
        {
            return View("Login", utilizadorDTO);
        }



        return View("~/Views/HomeUtente/Index.cshtml");
    }
}
