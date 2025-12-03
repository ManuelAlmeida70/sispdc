using Microsoft.AspNetCore.Mvc;

namespace SisPDC.Controllers;
public class LoginController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult CriarContaUtente()
    {
        return View();
    }

    public IActionResult IniciarSessao()
    {
        return View("~/Views/Especialidade/Index.cshtml");
    }
}
