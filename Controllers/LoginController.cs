using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.Controllers;
public class LoginController : Controller
{
    public IActionResult Login()
    {
        TempData["ErrorMessage"] = "Palavra ou email errado!";
        return View();
    }

    [HttpGet]
    public IActionResult CriarContaUtente()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CriarContaUtente(UtenteDTO utenteDTO)
    {
        if (ModelState.IsValid)
        {
            
        }
        return View();
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
