using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisPDC.DTOs;
using SisPDC.Services.Utente.Add;
using SisPDC.Services.Utilizador.VerificarSessao;
using System.Security.Claims;

namespace SisPDC.Controllers;
public class LoginController : Controller
{
    private readonly IVerificarSessao _verificarSessao;
    
    public LoginController(IVerificarSessao verificarSessao)
    {
        _verificarSessao = verificarSessao;
        
    }

    [AllowAnonymous]
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


    [HttpPost]
    public async Task<IActionResult> IniciarSessao(UtilizadorDTO utilizadorDTO)
    {
        if (!ModelState.IsValid)
        {
            return View("Login", utilizadorDTO);
        }

        var result = await _verificarSessao.VerificarLogin(utilizadorDTO);

        if (!result.Status)
        {
            TempData["ErrorMessage"] = result.Message;
            return View("Login", utilizadorDTO);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, result.Data.Nome),
            new Claim(ClaimTypes.NameIdentifier, result.Data.IdUtilizador.ToString()),
            new Claim(ClaimTypes.Email, result.Data.Email),
            new Claim(ClaimTypes.Role, result.Data.TipoUtilizador),
            new Claim("DataCriacao", DateTime.Now.ToString())
        };

        var claimsIdentify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8),
            AllowRefresh = true
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentify),
            authProperties);

        TempData["SuccessMessage"] = result.Message;

        return RedirectionBaseadoNoRole(result.Data.TipoUtilizador);
       
    }

    
    public async Task<IActionResult> TerminarSessao()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        TempData["Successmessage"] = "Sessão encerrada com sucesso!";
        return RedirectToAction("Login", "Login");
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
