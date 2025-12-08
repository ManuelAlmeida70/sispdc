using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Services.Utente.Add;
using SisPDC.Services.Utilizador.VerificarSessao;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SisPDC.Controllers;
public class LoginController : Controller
{
    private readonly IVerificarSessao _verificarSessao;
    public LoginController(IVerificarSessao verificarSessao)
    {
        _verificarSessao = verificarSessao;
    }

    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return RedirectionBaseadoNoRole(role);
        }
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

            if (utente.Status)
            {
                TempData["SuccessMessage"] = utente.Message;
                return RedirectToAction("Login");

            }
            TempData["ErrorMessage"] = utente.Message;
            
        }

        return View(utenteDTO);
    }

    public async Task<IActionResult> IniciarSessao(UtilizadorDTO utilizadorDTO)
    {
        if (ModelState.IsValid)
        {
            var utilizador = await _verificarSessao.VerificarLogin(utilizadorDTO);

            if (utilizador.Status)
            {
                TempData["SuccessMessage"] = utilizador.Message;
                if (utilizadorDTO.TipoUtilizador!.Equals("Utente"))
                {
                    return RedirectToAction("Index", "HomeUtente");
                }
            }
            else
            {
                TempData["ErrorMessage"] = utilizador.Message;
                return View("Login", utilizadorDTO);
            }

                return View("Login", utilizadorDTO);
        }
        else
        {
            return RedirectToAction("Login");
        }



        return View("~/Views/HomeUtente/Index.cshtml");
    }


    private IActionResult RedirectionBaseadoNoRole(string? role)
    {
        return role switch
        {
            "Utente" => RedirectToAction("Index", "HomeUtente"),
            "PessaoaAdministrativa" => RedirectToAction("Index", "Home"),
            "PessoaClinica" => RedirectToAction("Index", "HomePessoaClinica"),
            _ => RedirectToAction("Login"),
        };
    }
}
